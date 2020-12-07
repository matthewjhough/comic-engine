using System;
using ComicEngine.Shared;
using HotChocolate.Types;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Types {
    public class QueryType : ObjectType<Query> {
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (QueryType));

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
                        Logger.LogError (ex, "An error occured while executing {queryName}", context.Field.Name);
                        context.ReportError (ex.Message);
                        throw;
                    }
                });

            descriptor
                .Field (t => t.UserComics (default))
                .Type<ListType<UserComicType>> ()
                .Use (next => async context =>
                {
                    try {
                        // Log here
                        await next (context);
                    } catch (Exception ex) {
                        Logger.LogError (ex, "An error occured while executing {queryName}", context.Field.Name);
                        context.ReportError (ex.Message);
                        throw;
                    }
                });
        }
    }
}