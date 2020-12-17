import React, {useEffect} from "react";
import {AbstractSelect} from "../AbstractSelect/AbstractSelect";
import styles from "./StorageContainersDropdown.module.scss";

export function StorageContainersDropdown({ getStorageContainers, storageContainers = [] }) {
    useEffect(() => {
        getStorageContainers();
    }, [getStorageContainers]);
    
    return (<div className={styles.dropdownWrapper}>
        <AbstractSelect options={storageContainers.results.map(container => ({value: container, label: container.label}))} />
    </div>)
}