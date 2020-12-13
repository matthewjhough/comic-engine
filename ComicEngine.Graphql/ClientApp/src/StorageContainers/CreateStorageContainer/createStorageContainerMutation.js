export const createStorageContainerMutation = `
mutation createStorageContainer($storageContainer: StorageContainerInput!, $userId: String!){
  createStorageContainer(storageContainer: $storageContainer, userId: $userId){
    id
    label
    userId
  }
}
`;