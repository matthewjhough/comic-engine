export const comicByUpcQuery = `query($upc: String){ 
    comicByUpc(upc:$upc) { 
      id
      title
      copyright
      thumbnail
      description
      copyright
    } 
  }`;
