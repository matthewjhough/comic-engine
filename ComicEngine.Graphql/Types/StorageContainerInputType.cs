using ComicEngine.Shared.StorageContainers;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types
{
    public class StorageContainerInputType : InputObjectType<StorageContainer>
    {
        protected override void Configure(IInputObjectTypeDescriptor<StorageContainer> descriptor)
        {
            descriptor.Field (t => t.Id).Type<IntType> ();
        }
    }
}