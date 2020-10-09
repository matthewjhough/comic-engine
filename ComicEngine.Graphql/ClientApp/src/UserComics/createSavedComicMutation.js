export const createSavedComicMutation = `
mutation createSavedComic($comic: ComicInput!, $userId: String!) {
    createSavedComic(comic: $comic, userId: $userId) {
        id
        title
        copyright
        thumbnail
        description
        issueNumber
        pageCount
        characters {
          items {
            name
          }
        }
        publishDates {
          type
          _Date
        }
        relevantLinks {
          url
          type
        }
        resourceUri
        series {
          name
          resourceUri
        }
        thumbnail
    }
}
`;
