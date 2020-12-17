import React, { useEffect } from 'react';
import styles from './ComicSearchForm.module.scss';
import { ComicResultsContainer } from '../ComicResults/ComicResultsContainer';
import { AbstractInput } from '../AbstractInput/AbstractInput';
import { AbstractButton } from '../AbstractButton/AbstractButton';
import {StickyContainer} from "../StickyContainer/StickyContainer";
import {StorageContainersDropdownContainer} from "../StorageContainers/StorageContainersDropdownContainer";
import {ComicResult} from "../ComicResults/ComicResult";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import { faArchive, faWindowClose } from '@fortawesome/free-solid-svg-icons'

export function ComicSearchForm({
  updateIssueNumberInput,
  updateTitleInput,
  updateResultsFromForm,
  setSelectedComic,
  makeSaveComicRequest,
  toggleComicSearchLoadingTrue,
  selectedComic,
  title,
  issueNumber
}) {
  const isComicSelected = (currentComicId, savedComicId) => {
    return currentComicId === savedComicId;
  };

  const clearForm = () => {
    updateIssueNumberInput('');
    updateTitleInput('');
    setSelectedComic({});
  };

  useEffect(() => {
    setSelectedComic({});
  }, [setSelectedComic]);

  return (
    <div className={styles.comicSearchForm}>
      <form
        className={styles.comicSearchFormElement}
        onSubmit={e => {
          e.preventDefault();

          setSelectedComic({});
          toggleComicSearchLoadingTrue();
          updateResultsFromForm({ title, issueNumber });
        }}>
        <div className={styles.block}>
          <div className={styles.formRow}>
            <label>Title</label>
            <AbstractInput
              value={title}
              onChange={e => updateTitleInput(e.target.value)}
              name="title"
            />
          </div>
          <div className={styles.formRow}>
            <label>Issue Number</label>
            <AbstractInput
              value={issueNumber}
              onFocus={() => updateIssueNumberInput('')}
              onChange={e => updateIssueNumberInput(e.target.value)}
              name="issueNumber"
            />
          </div>
        </div>
        <div className={styles.buttonWrapper}>
          <AbstractButton type="submit">Search</AbstractButton>
          <AbstractButton onClick={() => clearForm()}>Clear</AbstractButton>
        </div>
      </form>
      <ComicResultsContainer
        selectComic={setSelectedComic}
        selectedComicId={selectedComic.id}>
        {selectedComic.id ? (
            <StickyContainer>
              <div className={styles.storageContainerSection}>
                <div onClick={() => setSelectedComic(selectedComic)}  className={styles.closeX}>
                  <FontAwesomeIcon icon={faWindowClose} />
                </div>
                <label>Select Storage Container:</label>
                <div className={styles.storageContainersDropdown}>
                  <div className={styles.iconBox}><FontAwesomeIcon icon={faArchive} /></div>
                  <StorageContainersDropdownContainer />
                </div>
                <ComicResult comic={selectedComic} />
              </div>
              <AbstractButton 
                  onClick={() => {
                    console.log("ComicSearchForm:: saving selected comic...", selectedComic);
                    makeSaveComicRequest(selectedComic);
                    console.log("ComicSearchForm:: Save operation complete.")
                    setSelectedComic({});
              }}>
                Save Comic
              </AbstractButton>
            </StickyContainer>
        ) : (
          ''
        )}
      </ComicResultsContainer>
    </div>
  );
}
