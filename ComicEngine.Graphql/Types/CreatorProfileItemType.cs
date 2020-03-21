using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class CreatorProfileItemType : ObjectType<CreatorProfileItem> {
        protected override void Configure (IObjectTypeDescriptor<CreatorProfileItem> descriptor) { }
    }
}