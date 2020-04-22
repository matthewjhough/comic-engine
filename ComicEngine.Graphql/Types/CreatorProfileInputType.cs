using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class CreatorProfileInputType : InputObjectType<CreatorProfile> {
        protected override void Configure (IInputObjectTypeDescriptor<CreatorProfile> descriptor) {
            descriptor.Field (t => t.Id).Type<IntType> ();
            descriptor.Field (t => t.Available).Type<IntType> ();
            descriptor.Field (t => t.Returned).Type<IntType> ();
            descriptor.Field (t => t.CollectionUri).Type<StringType> ();

            descriptor.Field (t => t.Items).Type<ListType<CreatorProfileItemInputType>> ();
        }
    }
}