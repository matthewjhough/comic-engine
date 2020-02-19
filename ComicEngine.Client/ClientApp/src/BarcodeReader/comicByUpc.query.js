export const comicByUpcQuery = `query($upc: String){ 
    comic(upc:$upc) { 
      id
      title
      copyright
      thumbnail
      description
      copyright
    } 
  }`;
