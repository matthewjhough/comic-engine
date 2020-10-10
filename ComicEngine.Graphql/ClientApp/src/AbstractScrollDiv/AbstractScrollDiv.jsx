import React from 'react';
import styles from './AbstractScrollDiv.module.scss';

export function AbstractScrollDiv({ children }) {
  return <div className={styles.scrollDiv}>{children}</div>;
}
