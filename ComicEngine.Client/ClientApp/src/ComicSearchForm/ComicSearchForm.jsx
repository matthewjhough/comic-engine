import React from 'react';
import { ComicResult } from '../ComicResult/ComicResult';
import styles from './ComicSearchForm.module.scss';

export function ComicSearchForm({
  updateIssueNumberInput,
  updateTitleInput,
  updateResultsFromForm,
  title,
  issueNumber,
  results
}) {
  return (
    <>
      <form
        onSubmit={e => {
          e.preventDefault();

          console.log('Form submitted.');
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
      {results.map(comic => (
        <ComicResult comic={comic} />
      ))}
    </>
  );
}
