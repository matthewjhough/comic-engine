import {comicEngineUserManager} from "../../Authorization/ComicEngineUserManager";
import {toggleLoading} from "../../ComicResults/comicResultsActions";
import {makeGraphqlRequest} from "../../graphqlClient/graphqlClient";
import {NotificationManager} from "react-notifications";
import {createStorageContainerMutation} from "./createStorageContainerMutation";
import {getStorageContainers} from "../GetStorageContainers/getStorageContainersAction";


export function createStorageContainer(storageContainerLabel) {
    
    if (!storageContainerLabel) {
        NotificationManager.error(
            'Save failed.',
            `Label cannot be blank.`
        );
        return function(dispatch) {
            return new Promise(() => console.error("no label provided.")).then(() => {});
        }
    }
    
    return function(dispatch) {
        return comicEngineUserManager.getUser().then(user => {
            const userId = user.profile.sub;
            console.action("createStorageContainer:: Current user subject: ", user.profile.sub);
            dispatch(toggleLoading(true));

            const storageContainer = {
                label: storageContainerLabel,
                userId
            };

            console.action('createStorageContainer:: making request...', storageContainer);
            return makeGraphqlRequest(createStorageContainerMutation, {
                storageContainer: storageContainer,
                userId: user.profile.sub
            })
                .then(res => res.json())
                .then(({ data, errors, ...rest }) => {
                    console.action("createStorageContainer:: response data: ", data, rest);
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

                    console.action('createStorageContainer:: saved to database.', data);
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
                })
                .then(() => dispatch(getStorageContainers()));
        });
    };
}