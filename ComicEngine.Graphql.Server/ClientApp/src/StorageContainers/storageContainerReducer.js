import {
    SET_STORAGE_CONTAINERS,
    SET_SELECTED_STORAGE_CONTAINER
} from "../actionTypes";

const defaultState = {
    results: [],
    selected: {}
};

export function storageContainersReducer(state = defaultState, action) {
    switch (action.type) {
        case SET_STORAGE_CONTAINERS:
            return { 
                ...state, 
                results: action.storageContainers 
            };
        case SET_SELECTED_STORAGE_CONTAINER:
            return {
                ...state,
                selected: action.selectedStorageContainer
            }
        default:
            return state;
    }
}