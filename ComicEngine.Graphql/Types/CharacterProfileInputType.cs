using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class CharacterProfileInputType : InputObjectType<CharacterProfile> {
        protected override void Configure (IInputObjectTypeDescriptor<CharacterProfile> descriptor) {
            descriptor.Field (t => t.Id).Type<IntType> ();

            descriptor.Field (t => t.Available).Type<NonNullType<IntType>> ();
            descriptor.Field (t => t.Returned).Type<NonNullType<IntType>> ();
            descriptor.Field (t => t.CollectionUri).Type<NonNullType<StringType>> ();

            descriptor.Field (t => t.Items).Type<ListType<CharacterProfileItemInputType>> ();
        }
    }
}