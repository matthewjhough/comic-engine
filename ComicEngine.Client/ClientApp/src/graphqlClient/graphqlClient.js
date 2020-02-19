import { comicByUpcQuery } from './queries/comicByUpc.query';
import { comicByTitleAndIssueNumber } from './queries/comicByTitleAndIssueNumber.query';

export const fetchComicFromBarcode = codeResult =>
  fetch('/graphql', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      query: comicByUpcQuery,
      variables: {
        upc: codeResult
      }
    })
  });

export const fetchComicFromTitleAndIssueNumber = ({ title, issueNumber }) =>
  fetch('/graphql', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      query: comicByTitleAndIssueNumber,
      variables: {
        title,
        issueNumber
      }
    })
  });

// TODO: create a more reusable http client to make graphql requests
