export const getUserComicsQuery = `
query userComics($userId: String!) {
    userComics(userId: $userId) {
        id
        userId
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
