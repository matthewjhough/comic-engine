export const getUserComicsQuery = `
query userComics($userId: String!) {
    userComics(userId: $userId) {
        id
        title
        copyright
        thumbnail
        description
    }
  }
`;
