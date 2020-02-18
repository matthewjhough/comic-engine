import { comicByUpcQuery } from './queries/comicByUpc.query';

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

// TODO: create a more reusable http client to make graphql requests
