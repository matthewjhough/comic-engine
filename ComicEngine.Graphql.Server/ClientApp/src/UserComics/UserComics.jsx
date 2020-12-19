import React, { useEffect } from 'react';
import {getOrDefault} from "../utilities";
import { AbstractContentWrapper } from '../AbstractContentWrapper/AbstractContentWrapper';
import { AbstractFlexContainer } from '../AbstractFlexContainer/AbstractFlexContainer';
import { AbstractTable } from "../AbstractTable/AbstractTable";
import {createUserComicBody, createUserComicHeaders} from "./GetUserComics/generateUserComicTable";
import {StorageContainers} from "../StorageContainers/StorageContainers";

export function UserComics({ 
     toggleLoading, 
     getUserComics,
     deleteUserComic,
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
  
  const getUserComicValue = (index, results) => results[index];

  // TODO: do this logic on change, not on render
  const firstResultOrDefault = getOrDefault(results, "0", []);
  const headers = createUserComicHeaders(firstResultOrDefault);
  const body = createUserComicBody(headers, results);
  
  return (
    <AbstractContentWrapper>
      <AbstractFlexContainer isColumn>
        <StorageContainers />
        <div>Comics in my Collection:</div>
        <AbstractTable 
            headers={headers} 
            body={body} 
            deleteBadge={true} 
            badgeHandler={(rowValues, index) => {
                const selectedUserComic = getUserComicValue(index, results);
                console.user("UserComics user selected comic for deletion: ", selectedUserComic);
                
                deleteUserComic(selectedUserComic);
                console.user("UserComics user delete action complete.", selectedUserComic);
            }} 
        />
      </AbstractFlexContainer>
    </AbstractContentWrapper>
  );
}
