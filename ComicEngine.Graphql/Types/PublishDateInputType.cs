using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class PublishDateInputType : InputObjectType<ComicDate> {
        protected override void Configure (IInputObjectTypeDescriptor<ComicDate> descriptor) {
            descriptor.Field (t => t.ComicDateId).Type<IntType> ();

            descriptor.Field (t => t._Date).Type<NonNullType<DateTimeType>> ();
            descriptor.Field (t => t.Type).Type<NonNullType<StringType>> ();
        }
    }
}