export const fetchComicFromBarcode = codeResult =>
  fetch('/graphql', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      query: `query($upc: String){ 
        comic(upc:$upc) { 
          id
          title
          copyright
          thumbnail
          description
          copyright
        } 
      }`,
      variables: {
        upc: codeResult
      }
    })
  });
