import React, { useEffect } from 'react';
import { AbstractContentWrapper } from '../AbstractContentWrapper/AbstractContentWrapper';
import { AbstractFlexContainer } from '../AbstractFlexContainer/AbstractFlexContainer';
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
    <AbstractContentWrapper>
      <AbstractFlexContainer isColumn>
        <ComicResultsContainer />
      </AbstractFlexContainer>
    </AbstractContentWrapper>
  );
}
