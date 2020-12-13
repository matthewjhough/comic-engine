import {comicEngineUserManager} from "../../Authorization/ComicEngineUserManager";
import {toggleLoading} from "../../ComicResults/comicResultsActions";
import {makeGraphqlRequest} from "../../graphqlClient/graphqlClient";
import {NotificationManager} from "react-notifications";
import {createStorageContainerMutation} from "./createStorageContainerMutation";


export function createStorageContainer(storageContainer) {
    console.log('createStorageContainer:: making request...', storageContainer);
    return function(dispatch) {
        return comicEngineUserManager.getUser().then(user => {
            console.log("createStorageContainer:: Current user subject: ", user.profile.sub);
            dispatch(toggleLoading(true));

            return makeGraphqlRequest(createStorageContainerMutation, {
                storageContainer: storageContainer,
                userId: user.profile.sub
            })
                .then(res => res.json())
                .then(({ data, errors }) => {
                    if (errors && errors.length > 0) {
                        console.error(
                            'createStorageContainer:: something went wrong.',
                            errors,
                            storageContainer
                        );
                        NotificationManager.error(
                            'Save failed.',
                            `${storageContainer.title} was not added to Storage Containers`
                        );
                        return dispatch(() => {});
                    }

                    console.log('createStorageContainer:: saved to database.', data);
                    NotificationManager.success(
                        'Success',
                        `${storageContainer.title} added to Storage Containers`
                    );

                    // TODO: do something with saved comic result
                    if (data.createStorageContainer == null) {
                        return dispatch(() => {});
                    }

                    // TODO: do something with storage client result
                    return dispatch(() => {});
                }).then(() => {
                    dispatch(toggleLoading(false));
                });
        });
    };
}