export const getSavedComicsQuery = `
query savedComics($userId: String!) {
    savedComics(userId: $userId) {
        id
        title
        copyright
        thumbnail
        description
    }
  }
`;
