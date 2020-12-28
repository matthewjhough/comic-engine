export const getUserComicsQuery = `
query userComics($userId: String!) {
    userComics(userId: $userId) {
        id
        userId
        storageContainer {
         label
         id
        }
        comic {
            id
            title
            copyright
            thumbnail
            description
        }
    }
  }
`;
