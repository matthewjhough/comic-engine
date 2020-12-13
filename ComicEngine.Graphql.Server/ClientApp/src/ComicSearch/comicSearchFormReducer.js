import { UPDATE_TITLE_INPUT, UPDATE_ISSUE_NUMBER_INPUT } from '../actionTypes';

const defaultState = {
  title: '',
  issueNumber: ''
};

export function comicSearchFormReducer(state = defaultState, action) {
  switch (action.type) {
    case UPDATE_TITLE_INPUT:
      return { ...state, title: action.title };
    case UPDATE_ISSUE_NUMBER_INPUT:
      return { ...state, issueNumber: action.issueNumber };
    default:
      return state;
  }
}
