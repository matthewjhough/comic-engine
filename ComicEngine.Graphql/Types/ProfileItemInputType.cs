using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class ProfileItemInputType
        : InputObjectType<ProfileItem> {
            protected override void Configure (IInputObjectTypeDescriptor<ProfileItem> descriptor) {

                descriptor.Field (t => t.Name).Type<NonNullType<StringType>> ();

                descriptor.Field (t => t.ResourceUri).Type<NonNullType<StringType>> ();

                descriptor.Field (t => t.Role).Type<NonNullType<StringType>> ();
            }
        }
}