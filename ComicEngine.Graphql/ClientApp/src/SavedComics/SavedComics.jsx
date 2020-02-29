import React from 'react';
import { ContentWrapper } from '../ContentWrapper/ContentWrapper';
import { FlexContainer } from '../FlexContainer/FlexContainer';
import { ComicResultsContainer } from '../ComicResults/ComicResultsContainer';

export function SavedComics() {
  return (
    <ContentWrapper>
      <FlexContainer isColumn>
        <ComicResultsContainer />
      </FlexContainer>
    </ContentWrapper>
  );
}
