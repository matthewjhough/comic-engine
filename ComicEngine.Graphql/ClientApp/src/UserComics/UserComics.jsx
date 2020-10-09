import React, { useEffect } from 'react';
import { ContentWrapper } from '../ContentWrapper/ContentWrapper';
import { FlexContainer } from '../FlexContainer/FlexContainer';
import { ComicResultsContainer } from '../ComicResults/ComicResultsContainer';

export function UserComics({ toggleLoading, getUserComics, clearResults }) {
  useEffect(() => {
    toggleLoading(true);
    getUserComics();

    return () => {
      clearResults();
    };
  }, [clearResults, getUserComics, toggleLoading]);

  return (
    <ContentWrapper>
      <FlexContainer isColumn>
        <ComicResultsContainer />
      </FlexContainer>
    </ContentWrapper>
  );
}
