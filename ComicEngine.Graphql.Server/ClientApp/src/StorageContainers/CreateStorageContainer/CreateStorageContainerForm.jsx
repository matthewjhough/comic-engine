import React, { useState } from "react";
import {AbstractInput} from "../../AbstractInput/AbstractInput";
import {AbstractButton} from "../../AbstractButton/AbstractButton";
import styles from "./CreateStorageContainerForm.module.scss";

export function CreateStorageContainerForm({ createStorageContainer }) {
    const [storageContainerLabel, setStorageContainerLabel] = useState("");
    
    console.log("storage container label value: ", storageContainerLabel);
    
    return (<div className={styles.createStorageContainerFormWrapper}>
        <form>
            <div className={styles.formRow}>
                <label>Container Name</label>
                <AbstractInput onChange={e => setStorageContainerLabel(e.target.value)} value={storageContainerLabel} />
            </div>
            <div>
                <AbstractButton onClick={() => createStorageContainer(storageContainerLabel)}>Add</AbstractButton>
            </div>
        </form>
    </div>)
}