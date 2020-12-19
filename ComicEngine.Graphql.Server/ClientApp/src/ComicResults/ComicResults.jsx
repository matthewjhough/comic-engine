import React from 'react';
import { AbstractScrollDiv } from '../AbstractScrollDiv/AbstractScrollDiv';
import { LoadingSpinner } from '../LoadingSpinner/LoadingSpinner';
import { ComicResult } from './ComicResult';
import styles from './ComicResults.module.scss';

export function ComicResults({
  searchResults = [],
  isLoading,
  selectedComicId,
  selectComic,
  isComicSelected,
  children
}) {
  const selectComicMethod = selectComic ? selectComic : () => {};
  return (
    <div className={styles.comicResults}>
      <div className={styles.resultsMessage}>Displaying {searchResults.length} results</div>
      <AbstractScrollDiv>
        {children}
        {isLoading ? (
          <LoadingSpinner />
        ) : (
          searchResults.map((comic, i) => (
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
