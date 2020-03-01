import React, { useEffect } from 'react';
import { ContentWrapper } from '../ContentWrapper/ContentWrapper';
import { FlexContainer } from '../FlexContainer/FlexContainer';
import { ComicResultsContainer } from '../ComicResults/ComicResultsContainer';

export function SavedComics({ toggleLoading, getSavedComics, clearResults }) {
  useEffect(() => {
    toggleLoading(true);
    getSavedComics();

    return () => {
      clearResults();
    };
  }, [clearResults, getSavedComics, toggleLoading]);

  return (
    <ContentWrapper>
      <FlexContainer isColumn>
        <ComicResultsContainer />
      </FlexContainer>
    </ContentWrapper>
  );
}
