import React from 'react';
import { Input } from 'reactstrap';
import styles from './AbstractInput.module.scss';

export function AbstractInput(props) {
  return <Input className={styles.abstractInput} {...props} />;
}
