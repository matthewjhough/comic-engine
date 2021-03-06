import React, { Component } from 'react';
import { initQuagga, deactivateQuagga } from './initQuagga';
import { ComicResult } from '../ComicResults/ComicResult';
import { BarcodeScanButton } from './BarcodeScanButton';
import { AbstractScrollDiv } from '../AbstractScrollDiv/AbstractScrollDiv';
import { MobileDeviceCheck } from '../MobileDeviceCheck/MobileDeviceCheck';

import styles from './BarcodeReader.module.scss';

export class BarcodeReader extends Component {
  state = {
    isScannerActive: false
  };

  onScannedCallback = ({ data }) => {
    const { comic } = data;
    this.setState({
      comic,
      isScannerActive: this.toggleScanner()
    });
  };

  toggleScanner = () => {
    const { onScannedCallback } = this;

    this.setState({ isScannerActive: !this.state.isScannerActive }, () => {
      if (this.state.isScannerActive) {
        this.setState({ comic: undefined });
        initQuagga(onScannedCallback);
      } else {
        deactivateQuagga();
      }
    });
  };

  render() {
    const { toggleScanner } = this;
    const { isScannerActive, comic } = this.state;

    return (
      <>
        <AbstractScrollDiv>
          <ComicResult comic={comic} />
          {isScannerActive ? (
            <>
              <div className={styles.scannerHeader}>
                <p className={styles.barcodeInstructionFeed}>
                  Point the camera feed below at the barcode.
                </p>
                <button className={styles.closeScanner} onClick={toggleScanner}>
                  X
                </button>
              </div>

              <div className={styles.barcodeReader} id="barcode_reader" />
            </>
          ) : (
            <MobileDeviceCheck>
              <BarcodeScanButton
                isResultDisplaying={comic && comic.title}
                onClick={toggleScanner}
              />
            </MobileDeviceCheck>
          )}
        </AbstractScrollDiv>
      </>
    );
  }
}
