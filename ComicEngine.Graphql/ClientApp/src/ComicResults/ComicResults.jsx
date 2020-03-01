import React from 'react';
import { ScrollContainer } from '../ScrollContainer/ScrollContainer';
import { LoadingSpinner } from '../LoadingSpinner/LoadingSpinner';
import { ComicResult } from '../ComicResult/ComicResult';
import styles from './ComicResults.module.scss';

export function ComicResults({ results = [], isLoading }) {
  return (
    <div className={styles.comicResults}>
      <ScrollContainer>
        {isLoading ? (
          <LoadingSpinner />
        ) : (
          results.map((comic, i) => (
            <ComicResult key={`${comic.id}-${i}`} comic={comic} />
          ))
        )}
      </ScrollContainer>
    </div>
  );
}
