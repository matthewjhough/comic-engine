import { comicByUpcQuery } from '../BarcodeReader/comicByUpc.query';
import authService from "../Authorization/AuthorizeService";

export const makeGraphqlRequest = (query, variables) =>
    authService.getUserJson().then(res => {
        const id_token =  res.id_token;
        return fetch('/graphql', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${id_token}`,
            },
            body: JSON.stringify({
                query,
                variables
            })
        });
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
