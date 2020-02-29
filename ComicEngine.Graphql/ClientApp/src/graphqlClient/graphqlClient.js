import { comicByUpcQuery } from '../BarcodeReader/comicByUpc.query';
import { comicByTitleAndIssueNumber } from '../ComicSearchForm/comicByComicSearchForm.query';

export const makeGraphqlRequest = (query, variables) =>
  fetch('/graphql', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      query,
      variables
    })
  });

// TODO: Refactor barcode scanner to use generic graphql client
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

// TODO: Refactor form to use generic graphql client
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
