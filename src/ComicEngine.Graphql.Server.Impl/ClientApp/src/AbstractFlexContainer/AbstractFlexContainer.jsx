import React from 'react';
import styles from './AbstractFlexContainer.module.scss';

export function AbstractFlexContainer({ children, isColumn }) {
  if (isColumn) {
    return (
      <div className={`${styles.flexContainer} ${styles.flexColumn}`}>
        {children}
      </div>
    );
  }

  return <div className={styles.flexContainer}>{children}</div>;
}
