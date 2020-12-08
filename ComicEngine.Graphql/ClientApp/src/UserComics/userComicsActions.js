import { NotificationManager } from 'react-notifications';
import { makeGraphqlRequest } from '../graphqlClient/graphqlClient';
import { setResults, toggleLoading } from '../ComicResults/comicResultsActions';
import { getUserComicsQuery } from './getUserComicsQuery';
import { createUserComicMutation } from './createUserComicMutation';
import { deleteUserComicMutation } from "./deleteUserComicMutation";
import { comicEngineUserManager } from "../Authorization/ComicEngineUserManager";

export function getUserComics() {
  return function(dispatch) {
    return comicEngineUserManager.getUser().then(user => {
        console.log("userComicsActions:: Current user subject: ", user.profile.sub);

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
  console.log('userComicsActions:: making saved comic request...', selectedComic);
  return function(dispatch) {
    console.log('userComicsActions:: dispatching selected comic...');
    return comicEngineUserManager.getUser().then(user => {
        console.log("userComicsActions:: Current user subject: ", user.profile.sub);
        dispatch(toggleLoading(true));
        
        return makeGraphqlRequest(createUserComicMutation, {
            comic: selectedComic,
            userId: user.profile.sub
        })
            .then(res => res.json())
            .then(({ data, errors }) => {
                if (errors && errors.length > 0) {
                    console.error(
                        'userComicsActions:: something went wrong saving comic.',
                        errors,
                        selectedComic
                    );
                    NotificationManager.error(
                        'Save failed.',
                        `${selectedComic.title} was not added to My Comics`
                    );
                    return dispatch(setResults({ results: [] }));
                }

                console.log('userComicsActions:: Comic saved to database.', data);
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
            }).then(() => {
                dispatch(toggleLoading(false));
            });
    });
  };
}

export function deleteUserComic(userComic) {
    return function(dispatch) {
        return comicEngineUserManager.getUser().then(user => {
            console.log("userComicsActions:: Current user subject: ", user.profile.sub);
            dispatch(toggleLoading(true));
            console.log("userComicsActions:: Deleting user comic: ", userComic)

            return makeGraphqlRequest(deleteUserComicMutation, {
                userId: user.profile.sub,
                userComicId: userComic.id
            })
                .then(res => res.json())
                .then(json => {
                    console.log("userComicsActions:: JSON returned from comic deletion: ", json);
                    
                    if (json && json.errors) {
                        console.error("userComicsActions:: List of errors from response: ", json.errors);
                        throw "Something went wrong.";
                    }
                    
                    if (json.data && !json.data.deleteUserComic) {
                        NotificationManager.error(
                            'Delete failed.',
                            `${userComic.title} was not removed from My Comics`
                        );
                        throw "Unable to delete comic";
                    }


                    console.log('userComicsActions:: Comic removed from database.', userComic);
                    NotificationManager.success(
                        'Removed',
                        `${userComic.comic.title} removed from My Comics`
                    );
                    
                    return json;
                })
                .then(() => dispatch(getUserComics()));
        })
    }
}
