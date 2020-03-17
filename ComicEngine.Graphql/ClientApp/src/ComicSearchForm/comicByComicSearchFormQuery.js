export const comicByTitleAndIssueNumber = `
query getMatchingComics($title: String, $issueNumber: String) {
    comicsByTitleAndIssueNumber(title: $title, issueNumber: $issueNumber) {
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
      characters {
        id
        available
        collectionUri
        items {
          id
          name
          role
          resourceUri
          characterProfileId
        }
      }
      creators {
        id
        returned
        available
        items {
          id
          name
          role
          resourceUri
          creatorProfileId
        }
      }
      resourceUri
      series {
        name
        resourceUri
      }
      thumbnail
    }
  }`;
