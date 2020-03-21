using System;
using ComicEngine.Graphql.Types;
using HotChocolate.Types;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Graphql {
    public class QueryType : ObjectType<Query> {
        private static ILogger _logger = ApplicationLogging.CreateLogger (nameof (QueryType));

        protected override void Configure (IObjectTypeDescriptor<Query> descriptor) {
            descriptor
                .Field (t => t.ComicByUpc (default))
                .Type<ComicType> ();

            descriptor
                .Field (t => t.ComicsByTitleAndIssueNumber (default, default))
                .Type<ListType<ComicType>> ()
                .Use (next => async context => {
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

            descriptor
                .Field (t => t.SavedComics ())
                .Type<ListType<ComicType>> ();
        }
    }
}