export const createStorageContainerMutation = `
mutation createStorageContainer($storageContainer: StorageContainerInput!){
  createStorageContainer(storageContainer: $storageContainer){
    id
    label
    userId
  }
}
`;