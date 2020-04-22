import React from 'react';
import styles from './StickyButton.module.scss';

// TODO: Swap out <button> for AbstractButton
export function StickyButton({ children, ...rest }) {
  return (
    <button className={styles.stickyButton} {...rest}>
      {children}
    </button>
  );
}
