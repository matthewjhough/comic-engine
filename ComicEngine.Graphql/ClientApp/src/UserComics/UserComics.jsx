import React, { useEffect } from 'react';
import {getOrDefault} from "../utilities";
import { AbstractContentWrapper } from '../AbstractContentWrapper/AbstractContentWrapper';
import { AbstractFlexContainer } from '../AbstractFlexContainer/AbstractFlexContainer';
import { AbstractTable } from "../AbstractTable/AbstractTable";
import {createUserComicBody, createUserComicHeaders} from "./createUserComicTable";

export function UserComics({ 
     toggleLoading, 
     getUserComics, 
     clearResults,
     results,
  }) {
  useEffect(() => {
    toggleLoading(true);
    getUserComics();

    return () => {
      clearResults();
    };
  }, [clearResults, getUserComics, toggleLoading]);

  console.log("UserComics 'results': ", results);
  // TODO: do this logic on change, not on render
  const firstResultOrDefault = getOrDefault(results, "0", []);
  const headers = createUserComicHeaders(firstResultOrDefault);
  const body = createUserComicBody(headers, results);
  console.log("UserComics generated headers: ", headers);
  console.log("UserComics generated body: ", body);
  
  return (
    <AbstractContentWrapper>
      <AbstractFlexContainer isColumn>
        <AbstractTable headers={headers} body={body} />
      </AbstractFlexContainer>
    </AbstractContentWrapper>
  );
}
