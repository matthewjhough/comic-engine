export const createSavedComicMutation = `
mutation createSavedComic($comicInput: ComicInput) {
    createSavedComic(comic: $comicInput) {
        id
        title
        copyright
        thumbnail
        description
        issueNumber
        pageCount
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
