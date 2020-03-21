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
                .Type<ComicType> ();

            descriptor
                .Field (t => t.SavedComics ())
                .Type<ComicType> ();
        }
    }
}