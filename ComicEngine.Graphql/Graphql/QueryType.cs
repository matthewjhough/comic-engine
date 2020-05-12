using System;
using ComicEngine.Common;
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
                // Move this out to reusable middleware for error reporting
                .Use (next => async context => {
                    try {
                        // Log here
                        await next (context);
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