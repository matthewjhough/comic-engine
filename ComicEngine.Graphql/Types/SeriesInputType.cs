using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class SeriesInputType : InputObjectType<ComicResource> {
        protected override void Configure (IInputObjectTypeDescriptor<ComicResource> descriptor) {
            descriptor.Field (t => t.ResourceUri).Type<NonNullType<StringType>> ();
            descriptor.Field (t => t.Name).Type<NonNullType<StringType>> ();
        }
    }
}