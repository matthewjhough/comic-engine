using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class ProfileItemType : ObjectType<GenericProfileItem> {
        protected override void Configure (IObjectTypeDescriptor<GenericProfileItem> descriptor) { }
    }
}