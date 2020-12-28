using ComicEngine.Shared.Comics;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Server.Impl.Types {
    public class ComicType : ObjectType<Comic> {
        protected override void Configure (IObjectTypeDescriptor<Comic> descriptor) { }
    }
}