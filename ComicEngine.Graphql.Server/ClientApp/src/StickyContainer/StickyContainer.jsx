import styles from "./StickyContainer.module.scss";
import React from "react";

export function StickyContainer({ children, ...rest }) {
    return (
        <div className={styles.stickyContainer} {...rest}>
            {children}
        </div>
    );
}