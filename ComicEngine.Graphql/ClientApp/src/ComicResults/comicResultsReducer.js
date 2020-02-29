import { SET_COMIC_RESULTS, TOGGLE_COMIC_SEARCH_LOADING } from '../actionTypes';

const defaultState = {
  results: [],
  isLoading: false
};

export function comicResultsReducer(state = defaultState, action) {
  switch (action.type) {
    case TOGGLE_COMIC_SEARCH_LOADING:
      return { ...state, isLoading: action.isLoading };
    case SET_COMIC_RESULTS:
      console.log('Results: ', action);
      return { ...state, results: action.results };
    default:
      return state;
  }
}
