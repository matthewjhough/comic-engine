using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class ProfileInputType : InputObjectType<Profile> {
        protected override void Configure (IInputObjectTypeDescriptor<Profile> descriptor) {
            descriptor.Field (t => t.Available).Type<NonNullType<IntType>> ();
            descriptor.Field (t => t.Returned).Type<NonNullType<IntType>> ();
            descriptor.Field (t => t.CollectionUri).Type<NonNullType<StringType>> ();
            // Add 'Items' field because EF doesn't support hiding methods at current time (3/21/2020)
            descriptor.Field (t => "Items").Type<ListType<ProfileItemInputType>> ();
        }
    }
}