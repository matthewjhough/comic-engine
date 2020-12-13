import {comicEngineUserManager} from "../../Authorization/ComicEngineUserManager";
import {setResults, toggleLoading} from "../../ComicResults/comicResultsActions";
import {makeGraphqlRequest} from "../../graphqlClient/graphqlClient";
import {createUserComicMutation} from "./createUserComicMutation";
import {NotificationManager} from "react-notifications";

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