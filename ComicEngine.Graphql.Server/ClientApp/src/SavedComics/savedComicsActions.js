import { NotificationManager } from 'react-notifications';
import { makeGraphqlRequest } from '../graphqlClient/graphqlClient';
import { setResults, toggleLoading } from '../ComicResults/comicResultsActions';
import { getSavedComicsQuery } from './getSavedComicsQuery';
import { createSavedComicMutation } from './createSavedComicMutation';

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
  console.log('making saved comic request...', selectedComic);
  return function(dispatch) {
    console.log('dispatching selected comic...');
    return makeGraphqlRequest(createSavedComicMutation, {
      comic: selectedComic
    })
      .then(res => res.json())
      .then(({ data, errors }) => {
        if (errors && errors.length > 0) {
          console.error(
            'something went wrong saving comic.',
            errors,
            selectedComic
          );
          NotificationManager.error(
            'Save failed.',
            `${selectedComic.title} was not added to My Comics`
          );
          return dispatch(setResults({ results: [] }));
        }

        console.log('Comic saved to database.', data);

        NotificationManager.success(
          'Success',
          `${selectedComic.title} added to My Comics`
        );

        // TODO: do something with saved comic result
        if (data.createSavedComic == null) {
          return dispatch(setResults({ results: [] }));
        }

        // TODO: do something with saved comic result
        return dispatch(setResults({ results: [] }));
      });
  };
}
