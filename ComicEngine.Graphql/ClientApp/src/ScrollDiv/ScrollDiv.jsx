import React from 'react';
import styles from './ScrollDiv.module.scss';

export function ScrollDiv({ children }) {
  return <div className={styles.scrollDiv}>{children}</div>;
}
