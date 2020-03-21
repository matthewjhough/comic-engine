using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class CharacterProfileItemType : ObjectType<CharacterProfileItem> {
        protected override void Configure (IObjectTypeDescriptor<CharacterProfileItem> descriptor) { }
    }
}