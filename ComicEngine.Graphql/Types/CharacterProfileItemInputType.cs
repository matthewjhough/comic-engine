using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class CharacterProfileItemInputType
        : InputObjectType<CharacterProfileItem> {
            protected override void Configure (IInputObjectTypeDescriptor<CharacterProfileItem> descriptor) {
                descriptor.Field (t => t.Id).Type<IntType> ();
                descriptor.Field (t => t.CharacterProfileId).Ignore (); //.Type<IntType> ();
                descriptor.Field (t => t.ComicStorageId).Type<IntType> ();

                descriptor.Field (t => t.Name).Type<NonNullType<StringType>> ();

                descriptor.Field (t => t.ResourceUri).Type<NonNullType<StringType>> ();

                descriptor.Field (t => t.Role).Type<StringType> ();
            }
        }
}