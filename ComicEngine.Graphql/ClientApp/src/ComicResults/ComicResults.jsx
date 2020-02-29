import React from 'react';
import { ScrollContainer } from '../ScrollContainer/ScrollContainer';
import { LoadingSpinner } from '../LoadingSpinner/LoadingSpinner';
import { ComicResult } from '../ComicResult/ComicResult';
import styles from './ComicResults.module.scss';

export function ComicResults({ results, isLoading, ...restState }) {
  return (
    <div className={styles.comicResults}>
      <ScrollContainer>
        {isLoading ? (
          <LoadingSpinner />
        ) : (
          results.map(comic => <ComicResult key={comic.id} comic={comic} />)
        )}
      </ScrollContainer>
    </div>
  );
}
