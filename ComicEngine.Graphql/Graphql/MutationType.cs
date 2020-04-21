using System;
using ComicEngine.Common.Comic;
using ComicEngine.Graphql.ComicEngineApi;
using ComicEngine.Graphql.Types;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Graphql {
    public class MutationType : ObjectType<Mutation> {

        private static ILogger _logger = ApplicationLogging.CreateLogger (nameof (MutationType));

        protected override void Configure (IObjectTypeDescriptor<Mutation> descriptor) {
            descriptor
                .Field (t => t.CreateSavedComic (default))
                .Type<ComicType> ()
                .Argument ("comic", a => a.Type<NonNullType<ComicInputType>> ())
                // Move this out to reusable middleware for error reporting
                .Use (next => async context => {
                    // try and move on through context
                    _logger.LogDebug ("Processing mutation: {mutationVariables}", context.Variables);
                    try {
                        await next (context);

                        if (context.Result is string s) {
                            context.Result = s.ToUpper ();
                        }
                    } catch (Exception ex) {
                        _logger.LogError (ex, "An error occured while exceuting {mutationName}", context.Field.Name);
                        context.ReportError (ex.Message);
                        throw;
                    }
                });
        }
    }
}