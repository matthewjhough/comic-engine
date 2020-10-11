export const comicByTitleAndIssueNumber = `
query comicsByTitleAndIssueNumber($title: String, $issueNumber: String) {
    comicsByTitleAndIssueNumber(title: $title, issueNumber: $issueNumber) {
      id
      title
      copyright
      thumbnail
      description
      issueNumber
      pageCount
      upc
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
        returned
        collectionUri
        items {
          id
          name
          role
          resourceUri
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
