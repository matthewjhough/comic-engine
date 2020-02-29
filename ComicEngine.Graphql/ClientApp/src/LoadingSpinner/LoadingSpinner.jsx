import React from 'react';
import styles from './LoadingSpinner.module.scss';

export function LoadingSpinner() {
  return (
    <div className={styles.spinnerBackground}>
      <div className={styles.loader} />
    </div>
  );
}
