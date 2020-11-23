export const getUserComicsQuery = `
query userComics($userId: String!) {
    userComics(userId: $userId) {
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
