import React from 'react';
import { Button } from 'reactstrap';
import styles from './AbstractButton.module.scss';

export function AbstractButton(props) {
  return <Button className={styles.abstractButton} {...props} />;
}
