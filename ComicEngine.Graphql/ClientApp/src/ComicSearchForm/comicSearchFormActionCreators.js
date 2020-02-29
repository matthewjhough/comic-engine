import {
  UPDATE_TITLE_INPUT,
  UPDATE_ISSUE_NUMBER_INPUT,
  SET_COMIC_FORM_RESULTS,
  TOGGLE_COMIC_SEARCH_LOADING
} from './comicSearchFormActionTypes';
import { fetchComicFromTitleAndIssueNumber } from '../graphqlClient/graphqlClient';

export function setComicFetchResults({ comicsByTitleAndIssueNumber }) {
  return {
    type: SET_COMIC_FORM_RESULTS,
    results: comicsByTitleAndIssueNumber
  };
}

export function toggleComicSearchLoading(isLoading) {
  return {
    type: TOGGLE_COMIC_SEARCH_LOADING,
    isLoading
  };
}

/**
 *
 * @param {object} comicForm
 */
export function updateResultsFromForm(dispatch) {
  return function(comicForm) {
    return fetchComicFromTitleAndIssueNumber(comicForm)
      .then(res => res.json())
      .then(({ data, errors }) => {
        if (errors && errors.length > 0) {
          return dispatch(
            setComicFetchResults({ comicsByTitleAndIssueNumber: [] })
          );
        }

        if (data.comicsByTitleAndIssueNumber == null) {
          return dispatch(
            setComicFetchResults({ comicsByTitleAndIssueNumber: [] })
          );
        }

        return dispatch(setComicFetchResults(data));
      })
      .then(() => dispatch(toggleComicSearchLoading(false)));
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
