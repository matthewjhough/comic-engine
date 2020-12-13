using ComicEngine.Shared.StorageContainers;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types
{
    public class StorageContainerType : ObjectType<StorageContainer>
    {
        protected override void Configure(IObjectTypeDescriptor<StorageContainer> descriptor)
        {
            descriptor.Field (t => t.Id).Type<IntType> ();
        }
    }
}