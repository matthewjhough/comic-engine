using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class CreatorProfileItemInputType
        : InputObjectType<CreatorProfileItem> {
            protected override void Configure (IInputObjectTypeDescriptor<CreatorProfileItem> descriptor) {
                descriptor.Field (t => t.Id).Type<IntType> ();
                descriptor.Field (t => t.CreatorProfileId).Ignore ();
                descriptor.Field (t => t.ComicStorageId).Ignore ();

                descriptor.Field (t => t.Name).Type<NonNullType<StringType>> ();

                descriptor.Field (t => t.ResourceUri).Type<NonNullType<StringType>> ();

                descriptor.Field (t => t.Role).Type<StringType> ();
            }
        }
}