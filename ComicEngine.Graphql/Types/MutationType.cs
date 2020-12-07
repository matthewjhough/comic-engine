using System;
using ComicEngine.Shared;
using HotChocolate.Types;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Types {
    public class MutationType : ObjectType<Mutation> {

        private static ILogger _logger = ApplicationLogging.CreateLogger (nameof (MutationType));

        protected override void Configure (IObjectTypeDescriptor<Mutation> descriptor) {
            descriptor
                .Field (t => t.CreateUserComic (default))
                .Type<UserComicType> ()
                .Argument ("comic", a => a.Type<NonNullType<ComicInputType>> ())
                .Argument("userId", a => a.Type<NonNullType<StringType>>())
                // Move this out to reusable middleware for error reporting
                .Use (next => async context => {
                    // try and move on through context
                    _logger.LogDebug ("Processing mutation: {mutationVariables}", context.Variables);
                    try {
                        // Log here
                        await next (context);
                    } catch (Exception ex) {
                        _logger.LogError (ex, "An error occured while exceuting {mutationName}", context.Field.Name);
                        context.ReportError (ex.Message);
                        throw;
                    }
                });
        }
    }
}