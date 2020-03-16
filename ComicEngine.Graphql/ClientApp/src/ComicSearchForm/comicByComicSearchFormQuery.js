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
      resourceUri
      series {
        name
        resourceUri
      }
      thumbnail
    }
  }`;
