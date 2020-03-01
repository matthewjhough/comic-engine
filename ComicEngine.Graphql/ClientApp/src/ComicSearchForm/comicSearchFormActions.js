import { UPDATE_TITLE_INPUT, UPDATE_ISSUE_NUMBER_INPUT } from '../actionTypes';
import { fetchComicFromTitleAndIssueNumber } from '../graphqlClient/graphqlClient';
import { setResults, toggleLoading } from '../ComicResults/comicResultsActions';

export function updateTitleInput(title) {
  return {
    type: UPDATE_TITLE_INPUT,
    title
  };
}

export function updateIssueNumberInput(issueNumber) {
  return {
    type: UPDATE_ISSUE_NUMBER_INPUT,
    issueNumber
  };
}

export function updateResultsFromForm(dispatch) {
  return function(comicForm) {
    return fetchComicFromTitleAndIssueNumber(comicForm)
      .then(res => res.json())
      .then(({ data, errors }) => {
        if (errors && errors.length > 0) {
          return dispatch(setResults({ results: [] }));
        }

        if (data.comicsByTitleAndIssueNumber == null) {
          return dispatch(setResults({ results: [] }));
        }

        return dispatch(
          setResults({ results: data.comicsByTitleAndIssueNumber })
        );
      })
      .then(() => dispatch(toggleLoading(false)));
  };
}
