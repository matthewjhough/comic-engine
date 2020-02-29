import React from 'react';
import styles from './ComicSearchForm.module.scss';
import { ComicResultsContainer } from '../ComicResults/ComicResultsContainer';

export function ComicSearchForm({
  updateIssueNumberInput,
  updateTitleInput,
  updateResultsFromForm,
  toggleComicSearchLoadingTrue,
  title,
  issueNumber,
  isLoading,
  results
}) {
  return (
    <div className={styles.comicSearchForm}>
      <form
        className={styles.comicSearchFormElement}
        onSubmit={e => {
          e.preventDefault();

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
              onChange={e => updateIssueNumberInput(e.target.value)}
              name="issueNumber"
            />
          </div>
        </div>
        <div className={styles.buttonWrapper}>
          <button type="submit">Search</button>
          <button
            onClick={() => {
              updateIssueNumberInput('');
              updateTitleInput('');
            }}>
            Clear
          </button>
        </div>
      </form>
      <ComicResultsContainer />
    </div>
  );
}
