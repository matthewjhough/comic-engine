import React from "react";
import {CreateStorageContainerFormContainer} from "./CreateStorageContainer/CreateStorageContainerFormContainer";
import {StorageContainersDropdownContainer} from "./StorageContainersDropdownContainer";

export function StorageContainers() {
    return (<div>
        <CreateStorageContainerFormContainer />
        <StorageContainersDropdownContainer />
        <br />
    </div>)
}