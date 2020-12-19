export const createUserComicMutation = `
mutation createUserComic(
    $comic: ComicInput!,
    $storageContainer: StorageContainerInput!,
    $userId: String!) {
    createUserComic(
        comic: $comic, 
        storageContainer: $storageContainer,
        userId: $userId) {
        storageContainer {
            label
            id
        }
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
