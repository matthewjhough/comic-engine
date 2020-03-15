import { NotificationManager } from 'react-notifications';
import { makeGraphqlRequest } from '../graphqlClient/graphqlClient';
import { setResults, toggleLoading } from '../ComicResults/comicResultsActions';
import { getSavedComicsQuery } from './getSavedComicsQuery';

export function getSavedComics() {
  return function(dispatch) {
    return makeGraphqlRequest(getSavedComicsQuery, {})
      .then(res => res.json())
      .then(({ data, errors }) => {
        if (errors && errors.length > 0) {
          return dispatch(setResults({ results: [] }));
        }

        if (data.savedComics == null) {
          return dispatch(setResults({ results: [] }));
        }

        return dispatch(setResults({ results: data.savedComics }));
      })
      .then(() => dispatch(toggleLoading(false)));
  };
}

export function makeSaveComicRequest(selectedComic) {
  NotificationManager.success(
    'Success message',
    `${selectedComic.title} added to My Comics`
  );
}
