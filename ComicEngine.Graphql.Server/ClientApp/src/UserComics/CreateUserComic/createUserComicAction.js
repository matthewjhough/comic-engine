import {comicEngineUserManager} from "../../Authorization/ComicEngineUserManager";
import {setResults, toggleLoading} from "../../ComicResults/comicResultsActions";
import {makeGraphqlRequest} from "../../graphqlClient/graphqlClient";
import {createUserComicMutation} from "./createUserComicMutation";
import {NotificationManager} from "react-notifications";

export function createUserComic(selectedComic, storageContainer) {
    console.action('createUserComic:: making saved comic request...', selectedComic, storageContainer);
    return function(dispatch) {
        console.action('createUserComic:: dispatching selected comic...');
        return comicEngineUserManager.getUser().then(user => {
            console.action("createUserComic:: Current user subject: ", user.profile.sub);
            dispatch(toggleLoading(true));

            return makeGraphqlRequest(createUserComicMutation, {
                comic: selectedComic,
                storageContainer: storageContainer,
                userId: user.profile.sub
            })
                .then(res => res.json())
                .then(({ data, errors }) => {
                    if (errors && errors.length > 0) {
                        console.error(
                            'createUserComic:: something went wrong saving comic.',
                            errors,
                            selectedComic
                        );
                        NotificationManager.error(
                            'Save failed.',
                            `${selectedComic.title} was not added to My Comics`
                        );
                        return dispatch(setResults({ results: [] }));
                    }

                    console.action('createUserComic:: Comic saved to database.', data);
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