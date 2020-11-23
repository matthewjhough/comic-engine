export const createUserComicMutation = `
mutation createUserComic($comic: ComicInput!, $userId: String!) {
    createUserComic(comic: $comic, userId: $userId) {
        comic {
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
}
`;
