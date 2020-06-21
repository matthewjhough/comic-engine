export const createSavedComicMutation = `
mutation createSavedComic($comic: ComicInput!) {
    createSavedComic(comic: $comic) {
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
