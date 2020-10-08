import React from 'react';
import styles from './FlexContainer.module.scss';

export function FlexContainer({ children, isColumn }) {
  if (isColumn) {
    return (
      <div className={`${styles.flexContainer} ${styles.flexColumn}`}>
        {children}
      </div>
    );
  }

  return <div className={styles.flexContainer}>{children}</div>;
}
