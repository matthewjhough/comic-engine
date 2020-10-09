import { NotificationManager } from 'react-notifications';
import { makeGraphqlRequest } from '../graphqlClient/graphqlClient';
import { setResults, toggleLoading } from '../ComicResults/comicResultsActions';
import { getUserComicsQuery } from './getUserComicsQuery';
import { createUserComicMutation } from './createUserComicMutation';
import {comicEngineUserManager} from "../Authorization/ComicEngineUserManager";

export function getUserComics() {
  return function(dispatch) {
    return comicEngineUserManager.getUser().then(user => {
        console.log("Current user subject: ", user.profile.sub);

        return makeGraphqlRequest(getUserComicsQuery, {
            userId: user.profile.sub
        })
            .then(res => res.json())
            .then(({ data, errors }) => {
                if (errors && errors.length > 0) {
                    return dispatch(setResults({ results: [] }));
                }

                if (data.userComics == null) {
                    return dispatch(setResults({ results: [] }));
                }

                return dispatch(setResults({ results: data.userComics }));
            })
            .then(() => dispatch(toggleLoading(false)))
    });
  };
}

export function createUserComic(selectedComic) {
  console.log('making saved comic request...', selectedComic);
  return function(dispatch) {
    console.log('dispatching selected comic...');
    return comicEngineUserManager.getUser().then(user => {
        console.log("Current user subject: ", user.profile.sub);
        
        return makeGraphqlRequest(createUserComicMutation, {
            comic: selectedComic,
            userId: user.profile.sub
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
                if (data.createUserComic == null) {
                    return dispatch(setResults({ results: [] }));
                }

                // TODO: do something with saved comic result
                return dispatch(setResults({ results: [] }));
            });
    });
  };
}
