using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class RelevantLinksInputType : InputObjectType<ComicUrl> {
        protected override void Configure (IInputObjectTypeDescriptor<ComicUrl> descriptor) {
            descriptor.Field (t => t.ComicUrlId).Type<IntType> ();
            descriptor.Field (t => t.Url).Type<NonNullType<StringType>> ();
            descriptor.Field (t => t.Type).Type<NonNullType<StringType>> ();
        }
    }
}