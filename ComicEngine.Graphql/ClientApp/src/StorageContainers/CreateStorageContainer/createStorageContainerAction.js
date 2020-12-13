import {comicEngineUserManager} from "../../Authorization/ComicEngineUserManager";
import {toggleLoading} from "../../ComicResults/comicResultsActions";
import {makeGraphqlRequest} from "../../graphqlClient/graphqlClient";
import {NotificationManager} from "react-notifications";
import {createStorageContainerMutation} from "./createStorageContainerMutation";


export function createStorageContainer(storageContainerLabel) {
    return function(dispatch) {
        return comicEngineUserManager.getUser().then(user => {
            const userId = user.profile.sub;
            console.log("createStorageContainer:: Current user subject: ", user.profile.sub);
            dispatch(toggleLoading(true));

            const storageContainer = {
                label: storageContainerLabel,
                userId
            };

            console.log('createStorageContainer:: making request...', storageContainer);
            return makeGraphqlRequest(createStorageContainerMutation, {
                storageContainer: storageContainer,
                userId: user.profile.sub
            })
                .then(res => res.json())
                .then(({ data, errors }) => {
                    console.log("createStorageContainer:: response data: ", data);
                    if (errors && errors.length > 0) {
                        console.error(
                            'createStorageContainer:: something went wrong.',
                            errors,
                            storageContainer
                        );
                        NotificationManager.error(
                            'Save failed.',
                            `${storageContainer.label} was not added to Storage Containers`
                        );
                        return dispatch(() => {});
                    }

                    console.log('createStorageContainer:: saved to database.', data);
                    NotificationManager.success(
                        'Success',
                        `${storageContainer.label} added to Storage Containers`
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