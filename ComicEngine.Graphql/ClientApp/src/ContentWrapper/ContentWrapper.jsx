import React from 'react';
import styles from './ContentWrapper.module.scss';

export function ContentWrapper({ children }) {
  return <div className={styles.contentWrapper}>{children}</div>;
}
