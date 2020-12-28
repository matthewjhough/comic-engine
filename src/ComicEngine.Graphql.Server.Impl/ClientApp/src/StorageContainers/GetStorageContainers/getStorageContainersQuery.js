export const getStorageContainersQuery = `
query storageContainers($userId: String!){
  storageContainers(userId: $userId){
    id
    label
    userId
  }
}
`;