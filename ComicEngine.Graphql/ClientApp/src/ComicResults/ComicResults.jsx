import React from 'react';
import { AbstractScrollDiv } from '../AbstractScrollDiv/AbstractScrollDiv';
import { LoadingSpinner } from '../LoadingSpinner/LoadingSpinner';
import { ComicResult } from './ComicResult';
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
      <AbstractScrollDiv>
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
      </AbstractScrollDiv>
    </div>
  );
}
