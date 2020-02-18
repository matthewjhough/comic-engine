import React, { Component } from 'react';
import { initQuagga } from './initQuagga';
import { ComicResult } from '../ComicResult/ComicResult';
import { BarcodeScanButton } from '../BarcodeScanButton/BarcodeScanButton';
import { ScrollContainer } from '../ScrollContainer/ScrollContainer';
import { barcodeReaderMockData } from './barcodeReaderMockData';
import { MobileDeviceCheck } from '../MobileDeviceCheck/MobileDeviceCheck';

import './BarcodeReader.css';

export class BarcodeReader extends Component {
  state = {
    isScannerActive: false
  };

  componentDidUpdate() {
    const { isScannerActive } = this.state;

    if (isScannerActive) {
      try {
        initQuagga(({ data }) => {
          const { comic } = data;
          this.setState({
            comic,
            isScannerActive: this.toggleScanner()
          });
        });
      } catch (error) {
        console.error('Error was caught: ', error);
      }
    }
  }

  toggleScanner = () =>
    this.setState({ isScannerActive: !this.state.isScannerActive }, () => {
      if (this.state.isScannerActive) {
        this.setState({ comic: undefined });
      }
    });

  render() {
    const { toggleScanner } = this;
    const { isScannerActive, comic } = this.state;

    const data = barcodeReaderMockData();

    return (
      <>
        <ScrollContainer>
          <ComicResult isScannerActive={isScannerActive} comic={comic} />
          {/* {data.map(comic => (
            <ComicResult comic={comic} />
          ))} */}
          {isScannerActive ? (
            <>
              <div className="scannerHeader">
                <p className="barcodeInstructionFeed">
                  Point the camera feed below at the barcode.
                </p>
                <button className="closeScanner" onClick={toggleScanner}>
                  X
                </button>
              </div>
              <div className="barcodeReader" id="barcode_reader" />
            </>
          ) : (
            <MobileDeviceCheck>
              <BarcodeScanButton
                isResultDisplaying={comic && comic.title}
                onClick={toggleScanner}
              />
            </MobileDeviceCheck>
          )}
        </ScrollContainer>
      </>
    );
  }
}
