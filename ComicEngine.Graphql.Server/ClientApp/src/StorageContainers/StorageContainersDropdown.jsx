import React, {useEffect} from "react";
import {AbstractSelect} from "../AbstractSelect/AbstractSelect";

export function StorageContainersDropdown({ getStorageContainers, storageContainers = [] }) {
    useEffect(() => {
        getStorageContainers();
    }, [getStorageContainers]);
    
    return (<AbstractSelect options={storageContainers.results.map(container => ({ 
        value: container, 
        label: container.label 
    }))} />)
}