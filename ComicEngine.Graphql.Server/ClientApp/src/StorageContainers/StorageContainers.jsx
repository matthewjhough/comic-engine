import React, { useState } from "react";
import {CreateStorageContainerFormContainer} from "./CreateStorageContainer/CreateStorageContainerFormContainer";
import {StorageContainersDropdownContainer} from "./StorageContainersDropdownContainer";
import styles from "./StorageContainers.module.scss";
import {AbstractButton} from "../AbstractButton/AbstractButton";

export function StorageContainers() {
    const [isCreating, setIsCreating] = useState(false);
    
    return (<div className={styles.storageContainersWrapper}>
        {isCreating ? (<CreateStorageContainerFormContainer />) : 
            (<><label>My Storage Containers:</label><StorageContainersDropdownContainer /></>)}
        <AbstractButton 
            className={styles.createNewButton} 
            onClick={() => setIsCreating(!isCreating)}>
                {!isCreating ? "New Container" : "Cancel"}
        </AbstractButton>
    </div>)
}