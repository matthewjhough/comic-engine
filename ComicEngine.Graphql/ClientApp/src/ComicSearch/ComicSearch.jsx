import React from 'react';
import { BarcodeReader } from '../BarcodeReader/BarcodeReader';
import { ComicSearchFormContainer } from '../ComicSearchForm/ComicSearchFormContainer';
import { MobileDeviceCheck } from '../MobileDeviceCheck/MobileDeviceCheck';
import { ContentWrapper } from '../ContentWrapper/ContentWrapper';

export function ComicSearch() {
  return (
    <ContentWrapper>
      <h5>Search for comics by Title and Issue number</h5>
      <MobileDeviceCheck>
        , or scan a barcode by clicking the scan button at the bottom of the
        screen.
        <BarcodeReader />
      </MobileDeviceCheck>
      <ComicSearchFormContainer />
    </ContentWrapper>
  );
}
