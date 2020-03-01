export const getSavedComicsQuery = `
query savedComics {
    savedComics {
        id
        title
        copyright
        thumbnail
        description
    }
  }
`;
