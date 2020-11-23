export const getUserComicsQuery = `
query userComics($userId: String!) {
    userComics(userId: $userId) {
        userId
        comic {
            id
            persistedComicId
            title
            copyright
            thumbnail
            description
        }
    }
  }
`;
