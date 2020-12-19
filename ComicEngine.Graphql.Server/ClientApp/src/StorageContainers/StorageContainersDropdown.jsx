import React, {useEffect} from "react";
import {AbstractSelect} from "../AbstractSelect/AbstractSelect";
import styles from "./StorageContainersDropdown.module.scss";

export function StorageContainersDropdown({
      setSelectedStorageContainer,
      getStorageContainers, 
      storageContainers = [] 
}) {
    useEffect(() => {
        getStorageContainers();
    }, [getStorageContainers]);
    
    return (<div className={styles.dropdownWrapper}>
        <AbstractSelect 
            onChange={container => 
                (console.log(container), setSelectedStorageContainer(container))} 
            options={storageContainers.results.map(container => 
                ({value: container, label: container.label}))} 
        />
    </div>)
}