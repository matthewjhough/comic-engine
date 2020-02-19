import {
  UPDATE_TITLE_INPUT,
  UPDATE_ISSUE_NUMBER_INPUT,
  SET_COMIC_FORM_RESULTS
} from './comicSearchFormActionTypes';
import { fetchComicFromTitleAndIssueNumber } from '../graphqlClient/graphqlClient';

export function setComicFetchResults({ comicsByTitleAndIssueNumber }) {
  return {
    type: SET_COMIC_FORM_RESULTS,
    results: comicsByTitleAndIssueNumber
  };
}

/**
 *
 * @param {object} comicForm
 */
export function updateResultsFromForm(dispatch) {
  return function(comicForm) {
    // send http request
    return fetchComicFromTitleAndIssueNumber(comicForm)
      .then(res => res.json())
      .then(({ data }) => dispatch(setComicFetchResults(data)));
  };
}

/**
 *
 * @param {string} title
 */
export function updateTitleInput(title) {
  return {
    type: UPDATE_TITLE_INPUT,
    title
  };
}

/**
 *
 * @param {string} issueNumber
 */
export function updateIssueNumberInput(issueNumber) {
  return {
    type: UPDATE_ISSUE_NUMBER_INPUT,
    issueNumber
  };
}
