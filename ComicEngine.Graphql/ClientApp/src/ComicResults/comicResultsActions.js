import {
  SET_COMIC_RESULTS,
  TOGGLE_COMIC_SEARCH_LOADING,
  SET_SELECTED_COMIC_RESULT, 
  SET_COMIC_SEARCH_RESULTS
} from '../actionTypes';

export function setResults({ results }) {
  return {
    type: SET_COMIC_RESULTS,
    results
  };
}

export function setComicSearchResults({ searchResults }) {
  return {
    type: SET_COMIC_SEARCH_RESULTS,
    searchResults
  };
}

export function toggleLoading(isLoading) {
  return {
    type: TOGGLE_COMIC_SEARCH_LOADING,
    isLoading
  };
}

export function setSelectedComic(selectedComic) {
  return {
    type: SET_SELECTED_COMIC_RESULT,
    selectedComic
  };
}
