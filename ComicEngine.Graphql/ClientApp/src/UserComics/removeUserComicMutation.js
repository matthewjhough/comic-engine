export const removeUserComicMutation = `
mutation removeUserComic(comicId: String!, $userId: String!) {
    removeUserComic(comicId: $comicId, userId: $userId) {
        id
        title
    }
}
`;