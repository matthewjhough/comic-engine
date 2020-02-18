import React from 'react';
import styles from './ScrollContainer.module.scss';

export function ScrollContainer({ children }) {
  return <div className={styles.scrollContainer}>{children}</div>;
}
