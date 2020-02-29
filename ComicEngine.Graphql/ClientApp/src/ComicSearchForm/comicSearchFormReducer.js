import {
  UPDATE_TITLE_INPUT,
  UPDATE_ISSUE_NUMBER_INPUT,
  SET_COMIC_FORM_RESULTS,
  TOGGLE_COMIC_SEARCH_LOADING
} from './comicSearchFormActionTypes';

const defaultState = {
  title: '',
  issueNumber: '',
  results: [],
  isLoading: false
};

export function comicSearchFormReducer(state = defaultState, action) {
  switch (action.type) {
    case TOGGLE_COMIC_SEARCH_LOADING:
      return { ...state, isLoading: action.isLoading };
    case SET_COMIC_FORM_RESULTS:
      return { ...state, results: action.results };
    case UPDATE_TITLE_INPUT:
      return { ...state, title: action.title };
    case UPDATE_ISSUE_NUMBER_INPUT:
      return { ...state, issueNumber: action.issueNumber };
    default:
      return state;
  }
}
