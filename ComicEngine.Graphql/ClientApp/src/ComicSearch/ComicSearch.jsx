import React from 'react';
import { ComicSearchFormContainer } from './ComicSearchFormContainer';
import { AbstractContentWrapper } from '../AbstractContentWrapper/AbstractContentWrapper';

export function ComicSearch() {
  return (
    <AbstractContentWrapper>
      <h5>Search for comics by Title and Issue number</h5>
      {/* <MobileDeviceCheck>
        , or scan a barcode by clicking the scan button at the bottom of the
        screen.
        <BarcodeReader />
      </MobileDeviceCheck> */}
      <ComicSearchFormContainer />
    </AbstractContentWrapper>
  );
}
