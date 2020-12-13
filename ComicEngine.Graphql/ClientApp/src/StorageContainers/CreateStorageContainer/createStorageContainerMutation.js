export const createStorageContainerMutation = `
mutation createStorageContainer($storageContainer: StorageContainer!, $userId: String!){
  createStorageContainer(storageContainer: $storageContainer, userId: $userId){
    id
    label
    userId
  }
}
`;