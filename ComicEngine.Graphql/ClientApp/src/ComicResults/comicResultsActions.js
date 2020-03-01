import { SET_COMIC_RESULTS, TOGGLE_COMIC_SEARCH_LOADING } from '../actionTypes';

export function setResults({ results }) {
  return {
    type: SET_COMIC_RESULTS,
    results
  };
}

export function toggleLoading(isLoading) {
  return {
    type: TOGGLE_COMIC_SEARCH_LOADING,
    isLoading
  };
}
