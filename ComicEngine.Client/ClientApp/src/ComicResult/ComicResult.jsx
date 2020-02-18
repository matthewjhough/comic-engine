import React from 'react';
import './ComicResult.css';

export function ComicResult({ comic, ...rest }) {
  if (!comic) {
    return <div />;
  }

  if (!comic.title) {
    return <p>No results found.</p>;
  }

  return (
    <div className="comicResult" {...rest}>
      <h3>{comic.title}</h3>
      <div className="contentContainer">
        <div className="imageContainer">
          <img
            className="comicResultImage"
            src={comic.thumbnail}
            alt={`${comic.title} thumbnail`}
          />
        </div>
        <div className="textContainer">
          <p>
            <span className="bold-font">Description:</span> {comic.description}
          </p>
          <p>
            <span className="bold-font">Copyright:</span> {comic.copyright}
          </p>
        </div>
      </div>
    </div>
  );
}
