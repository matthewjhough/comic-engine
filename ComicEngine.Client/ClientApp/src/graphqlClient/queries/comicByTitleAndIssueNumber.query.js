export const comicByTitleAndIssueNumber = `
query getMatchingComics($title: String, $issueNumber: String) {
    comicsByTitleAndIssueNumber(title: $title, issueNumber: $issueNumber) {
      id
      title
      copyright
      thumbnail
      description
    }
  }`;
