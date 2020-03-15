import React, { useEffect } from 'react';
import styles from './ComicSearchForm.module.scss';
import { StickyButton } from '../StickyButton/StickyButton';
import { ComicResultsContainer } from '../ComicResults/ComicResultsContainer';

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
            <input
              value={title}
              onChange={e => updateTitleInput(e.target.value)}
              name="title"
            />
          </div>
          <div className={styles.formRow}>
            <label>Issue Number</label>
            <input
              value={issueNumber}
              onFocus={() => updateIssueNumberInput('')}
              onChange={e => updateIssueNumberInput(e.target.value)}
              name="issueNumber"
            />
          </div>
        </div>
        <div className={styles.buttonWrapper}>
          <button type="submit">Search</button>
          <button onClick={() => clearForm()}>Clear</button>
        </div>
      </form>
      <ComicResultsContainer
        selectComic={setSelectedComic}
        isComicSelected={isComicSelected}
        selectedComicId={selectedComic.id}>
        {selectedComic.id ? (
          <StickyButton
            onClick={() => {
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
