using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class ComicInputType : InputObjectType<Comic> {
        protected override void Configure (IInputObjectTypeDescriptor<Comic> descriptor) {
            descriptor.Field (t => t.StorageId).Type<IntType> ().Ignore ();
            descriptor.Field (t => t.Id).Type<IntType> ();
            descriptor.Field (t => t.PersistedComicId).Type<IntType> ().Ignore ();
        }
    }
}