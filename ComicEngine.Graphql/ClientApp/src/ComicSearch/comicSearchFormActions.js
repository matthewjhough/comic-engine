import { UPDATE_TITLE_INPUT, UPDATE_ISSUE_NUMBER_INPUT } from '../actionTypes';
import { makeGraphqlRequest } from '../graphqlClient/graphqlClient';
import { comicByTitleAndIssueNumber } from './comicByComicSearchFormQuery';
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
  return function({ title, issueNumber }) {
      console.log("comicSearchFormActions:: searching for title, issueNumber", title, issueNumber);
    return makeGraphqlRequest(comicByTitleAndIssueNumber, {
      title,
      issueNumber
    })
      .then(res => res.json())
      .then(({ data, errors }) => {
        console.log('comicSearchFormActions:: results returned from api: ', data, errors);
        if (errors && errors.length > 0) {
          console.error('comicSearchFormActions:: An error occured retrieving results.', errors);
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
