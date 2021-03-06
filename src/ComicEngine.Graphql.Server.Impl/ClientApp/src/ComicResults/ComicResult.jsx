import React from 'react';
import styles from './ComicResult.module.scss';

export function ComicResult({ comic, isSelected, isWithoutBorder, ...rest }) {
  if (!comic) {
    return <div />;
  }

  if (!comic.title) {
    return <p>No results found.</p>;
  }

  return (
    <div
      className={`
      ${styles.comicResult} ${isWithoutBorder ? '' : styles.isWithoutBorder} 
      ${isSelected ? styles.isSelected : ''}`}
      {...rest}>
      <h3>{comic.title}</h3>
      <div className={styles.contentContainer}>
        <div className={styles.imageContainer}>
          <img
            className={styles.comicResultImage}
            src={comic.thumbnail}
            alt={`${comic.title} thumbnail`}
          />
        </div>
        <div className={styles.textContainer}>
          <p>
            <span className={styles.boldFont}>Description:</span>{' '}
            <span className={styles.textOverflow}>{comic.description}</span>
          </p>
          <p>
            <span className={styles.boldFont}>Copyright:</span>
            {comic.copyright}
          </p>
        </div>
      </div>
    </div>
  );
}
