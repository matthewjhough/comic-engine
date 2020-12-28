using ComicEngine.Shared.Comics;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Server.Impl.Types {
    public class ComicInputType : InputObjectType<Comic> {
        protected override void Configure (IInputObjectTypeDescriptor<Comic> descriptor) {
            descriptor.Field (t => t.Id).Type<IntType> ();
        }
    }
}