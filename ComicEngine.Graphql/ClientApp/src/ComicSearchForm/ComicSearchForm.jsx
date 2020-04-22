import React, { useEffect } from 'react';
import styles from './ComicSearchForm.module.scss';
import { StickyButton } from '../StickyButton/StickyButton';
import { ComicResultsContainer } from '../ComicResults/ComicResultsContainer';
import { AbstractInput } from '../AbstractInput/AbstractInput';
import { AbstractButton } from '../AbstractButton/AbstractButton';

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
        isComicSelected={isComicSelected}
        selectedComicId={selectedComic.id}>
        {selectedComic.id ? (
          <StickyButton
            onClick={() => {
              console.log(selectedComic);
              makeSaveComicRequest(selectedComic);
              setSelectedComic({});
            }}
            type="button">
            Save Comic
          </StickyButton>
        ) : (
          ''
        )}
      </ComicResultsContainer>
    </div>
  );
}
