import React from "react";
import {AbstractInput} from "../../AbstractInput/AbstractInput";
import {AbstractButton} from "../../AbstractButton/AbstractButton";
import styles from "./CreateStorageContainerForm.module.scss";

export function CreateStorageContainerForm() {
    return (<div className={styles.createStorageContainerFormWrapper}>
        <form>
            <div className={styles.formRow}>
                <label>Container Name</label>
                <AbstractInput />
            </div>
            <div>
                <AbstractButton onClick={() => console.log("CreateStorageContainerForm:: Added")}>Add</AbstractButton>
            </div>
        </form>
    </div>)
}