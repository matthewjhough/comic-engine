import React from 'react';
import { ScrollDiv } from '../ScrollDiv/ScrollDiv';
import { LoadingSpinner } from '../LoadingSpinner/LoadingSpinner';
import { ComicResult } from '../ComicResult/ComicResult';
import styles from './ComicResults.module.scss';

export function ComicResults({
  results = [],
  isLoading,
  selectedComicId,
  selectComic,
  isComicSelected,
  children
}) {
  const selectComicMethod = selectComic ? selectComic : () => {};

  return (
    <div className={styles.comicResults}>
      <ScrollDiv>
        {children}
        {isLoading ? (
          <LoadingSpinner />
        ) : (
          results.map((comic, i) => (
            <ComicResult
              key={`${comic.id}-${i}`}
              onClick={() => selectComicMethod(comic)}
              isSelected={
                isComicSelected && isComicSelected(comic.id, selectedComicId)
              }
              comic={comic}
            />
          ))
        )}
      </ScrollDiv>
    </div>
  );
}
