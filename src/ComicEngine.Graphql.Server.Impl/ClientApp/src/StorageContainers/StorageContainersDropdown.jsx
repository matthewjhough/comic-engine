import React, {useEffect} from "react";
import {AbstractSelect} from "../AbstractSelect/AbstractSelect";
import styles from "./StorageContainersDropdown.module.scss";

export function StorageContainersDropdown({
      setSelectedStorageContainer,
      getStorageContainers, 
      results = [],
      selected
}) {
    useEffect(() => {
        getStorageContainers();
    }, [getStorageContainers]);
    
    return (<div className={styles.dropdownWrapper}>
        <AbstractSelect 
            value={selected}
            onChange={container => setSelectedStorageContainer(container)} 
            options={results.map(container => 
                ({value: container, label: container.label}))} 
        />
    </div>)
}