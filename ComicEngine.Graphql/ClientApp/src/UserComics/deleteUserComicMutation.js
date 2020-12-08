export const deleteUserComicMutation = `
mutation deleteUserComic($userComicId: String!, $userId: String!){
    deleteUserComic(userComicId: $userComicId, userId: $userId)
}
`;