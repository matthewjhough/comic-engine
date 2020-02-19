import React from 'react';
import { ComicResult } from '../ComicResult/ComicResult';
import { LoadingSpinner } from '../LoadingSpinner/LoadingSpinner';
import styles from './ComicSearchForm.module.scss';

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
    <>
      <form
        onSubmit={e => {
          e.preventDefault();

          toggleComicSearchLoadingTrue();
          updateResultsFromForm({ title, issueNumber });
        }}>
        <div className={styles.block}>
          <div className={styles.formRow}>
            <label>Title</label>
            <input
              onChange={e => updateTitleInput(e.target.value)}
              name="title"
            />
          </div>
          <div className={styles.formRow}>
            <label>Issue Number</label>
            <input
              onChange={e => updateIssueNumberInput(e.target.value)}
              name="issueNumber"
            />
          </div>
        </div>
        <button type="submit">Search</button>
      </form>
      {isLoading ? (
        <LoadingSpinner />
      ) : (
        results.map(comic => <ComicResult key={comic.id} comic={comic} />)
      )}
      {}
    </>
  );
}
