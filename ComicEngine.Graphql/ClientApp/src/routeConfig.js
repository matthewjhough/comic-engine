import { SavedComicsContainer } from './SavedComics/SavedComicsContainer';
import { ComicSearch } from './ComicSearch/ComicSearch';

export const routeConfig = {
  comicSearch: {
    text: 'Comic Search',
    url: '/comic-search',
    component: ComicSearch
  },
  myComics: {
    text: 'My Comics',
    url: '/my-comics',
    component: SavedComicsContainer
  }
};
