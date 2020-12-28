import {comicEngineUserManager} from "../../Authorization/ComicEngineUserManager";
import {makeGraphqlRequest} from "../../graphqlClient/graphqlClient";
import {toggleLoading} from "../../ComicResults/comicResultsActions";
import {getStorageContainersQuery} from "./getStorageContainersQuery";
import {SET_STORAGE_CONTAINERS} from "../../actionTypes";

export function setStorageContainers({ storageContainers }) {
    return {
        type: SET_STORAGE_CONTAINERS,
        storageContainers
    };
}

export function getStorageContainers() {
    return function(dispatch) {
        return comicEngineUserManager.getUser().then(user => {
            console.action("userComicsActions:: Current user subject: ", user.profile.sub);
            toggleLoading(true);
            
            return makeGraphqlRequest(getStorageContainersQuery, {
                userId: user.profile.sub
            })
                .then(res => res.json())
                .then(({ data, errors }) => {
                    console.action("Storage containers data: ", data);
                    if (errors && errors.length > 0) {
                        return dispatch(setStorageContainers({ storageContainers: [] }));
                    }

                    if (!data.storageContainers) {
                        return dispatch(setStorageContainers({ storageContainers: [] }));
                    }

                    return dispatch(setStorageContainers({ storageContainers: data.storageContainers }));
                })
                .then(() => dispatch(toggleLoading(false)))
        });
    };
}