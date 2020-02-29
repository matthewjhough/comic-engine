import React from 'react';
import { BarcodeReader } from '../BarcodeReader/BarcodeReader';
import { ComicSearchFormContainer } from '../ComicSearchForm/ComicSearchFormContainer';
import { MobileDeviceCheck } from '../MobileDeviceCheck/MobileDeviceCheck';
import styles from './ComicSearch.module.scss';
import { ScrollContainer } from '../ScrollContainer/ScrollContainer';

export function ComicSearch() {
  return (
    <ScrollContainer>
      <div className={styles.comicSearch}>
        Search for comics by Title and Issue number
        <MobileDeviceCheck>
          , or scan a barcode by clicking the scan button at the bottom of the
          screen.
          <BarcodeReader />
        </MobileDeviceCheck>
        <ComicSearchFormContainer />
      </div>
    </ScrollContainer>
  );
}
