using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class ProfileType : ObjectType<GenericProfile> {
        protected override void Configure (IObjectTypeDescriptor<GenericProfile> descriptor) {
            descriptor.Field (t => t.Items).Type<ListType<ProfileItemType>> ();
        }
    }
}