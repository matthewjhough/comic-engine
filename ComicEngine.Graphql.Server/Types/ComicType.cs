using ComicEngine.Shared.Comics;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Server.Types {
    public class ComicType : ObjectType<Comic> {
        protected override void Configure (IObjectTypeDescriptor<Comic> descriptor) { }
    }
}