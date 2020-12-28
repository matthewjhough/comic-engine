using ComicEngine.Shared.StorageContainers;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Server.Impl.Types
{
    public class StorageContainerType : ObjectType<StorageContainer>
    {
        protected override void Configure(IObjectTypeDescriptor<StorageContainer> descriptor) {}
    }
}