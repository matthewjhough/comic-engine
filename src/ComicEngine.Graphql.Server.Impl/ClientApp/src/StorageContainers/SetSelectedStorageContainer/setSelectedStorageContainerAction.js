import { SET_SELECTED_STORAGE_CONTAINER } from "../../actionTypes";

export function setSelectedStorageContainer(selectedStorageContainer) {
    return {
        type: SET_SELECTED_STORAGE_CONTAINER,
        selectedStorageContainer: selectedStorageContainer.value
    };
}