import React from 'react';
import { BarcodeReader } from '../BarcodeReader/BarcodeReader';
import { ComicSearchFormContainer } from '../ComicSearchForm/ComicSearchFormContainer';
import { MobileDeviceCheck } from '../MobileDeviceCheck/MobileDeviceCheck';
import styles from './ComicSearch.module.scss';

export function ComicSearch() {
  return (
    <div className={styles.comicSearch}>
      <h5>Search for comics by Title and Issue number</h5>
      <MobileDeviceCheck>
        , or scan a barcode by clicking the scan button at the bottom of the
        screen.
        <BarcodeReader />
      </MobileDeviceCheck>
      <ComicSearchFormContainer />
    </div>
  );
}
