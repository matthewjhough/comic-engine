import {
  SET_COMIC_RESULTS,
  SET_SELECTED_COMIC_RESULT,
  TOGGLE_COMIC_SEARCH_LOADING
} from '../actionTypes';

const defaultState = {
  results: [],
  selectedComic: {},
  isLoading: false
};

function resolveSelectedComic(state, action) {
  if (
    action.selectedComic &&
    action.selectedComic.id === state.selectedComic.id
  ) {
    return { ...state, selectedComic: {} };
  }

  return {
    ...state,
    selectedComic: action.selectedComic
  };
}

export function comicResultsReducer(state = defaultState, action) {
  switch (action.type) {
    case SET_SELECTED_COMIC_RESULT:
      return resolveSelectedComic(state, action);
    case TOGGLE_COMIC_SEARCH_LOADING:
      return { ...state, isLoading: action.isLoading };
    case SET_COMIC_RESULTS:
      return { ...state, results: action.results };
    default:
      return state;
  }
}
