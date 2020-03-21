using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class CreatorProfileType : ObjectType<CreatorProfile> {
        protected override void Configure (IObjectTypeDescriptor<CreatorProfile> descriptor) {
            descriptor.Field (t => t.Items).Type<ListType<CreatorProfileItemType>> ();
        }
    }
}