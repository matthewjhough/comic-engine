import React, { Component } from 'react';
import { BarcodeScannerReader } from '../BarcodeScannerReader/BarcodeScannerReader';
import './BarcodeScanner.css';

export class BarcodeScanner extends Component {
  checkIfMobileDevice = () =>
    typeof window.orientation !== 'undefined' ||
    navigator.userAgent.indexOf('IEMobile') !== -1;

  render() {
    const { checkIfMobileDevice } = this;
    const isMobileDevice = true; // checkIfMobileDevice();

    return (
      <div className="barcodeScannerWrapper">
        {isMobileDevice ? (
          <BarcodeScannerReader />
        ) : (
          'Feature only available on mobile devices.'
        )}
      </div>
    );
  }
}
