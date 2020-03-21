using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class CharacterProfileType : ObjectType<CharacterProfile> {
        protected override void Configure (IObjectTypeDescriptor<CharacterProfile> descriptor) {
            descriptor.Field (t => t.Items).Type<ListType<CharacterProfileItemType>> ();
        }
    }
}