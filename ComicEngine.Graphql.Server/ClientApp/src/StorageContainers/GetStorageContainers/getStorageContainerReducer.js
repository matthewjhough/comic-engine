import {
    SET_STORAGE_CONTAINERS
} from "../../actionTypes";

const defaultState = {
    results: []
};

export function getStorageContainersReducer(state = defaultState, action) {
    switch (action.type) {
        case SET_STORAGE_CONTAINERS:
            return { 
                ...state, 
                results: action.storageContainers 
            };
        default:
            return state;
    }
}