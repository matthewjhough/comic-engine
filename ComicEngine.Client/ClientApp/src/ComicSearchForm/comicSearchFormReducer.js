import {
  UPDATE_TITLE_INPUT,
  UPDATE_ISSUE_NUMBER_INPUT,
  SET_COMIC_FORM_RESULTS
} from './comicSearchFormActionTypes';

const defaultState = {
  title: '',
  issueNumber: '',
  results: []
};

export function comicSearchFormReducer(state = defaultState, action) {
  switch (action.type) {
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
