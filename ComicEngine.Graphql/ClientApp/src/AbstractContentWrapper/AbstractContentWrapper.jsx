import React from 'react';
import styles from './AbstractContentWrapper.module.scss';

export function AbstractContentWrapper({ children }) {
  return <div className={styles.contentWrapper}>{children}</div>;
}
