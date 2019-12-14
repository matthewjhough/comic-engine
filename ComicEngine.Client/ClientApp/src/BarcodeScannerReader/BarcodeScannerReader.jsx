import React, { Component } from 'react';
import Quagga from 'quagga';
import './BarcodeScannerReader.css';

export class BarcodeScannerReader extends Component {
  state = {
    code: '',
    isScannerActive: false
  };

  componentDidUpdate() {
    const { isScannerActive } = this.state;

    if (isScannerActive) {
      Quagga.init(
        {
          inputStream: {
            name: 'Live',
            type: 'LiveStream',
            target: document.querySelector('#barcode_reader')
          },
          decoder: {
            readers: [
              {
                format: 'ean_reader',
                config: {
                  supplements: ['ean_5_reader', 'ean_2_reader']
                }
              }
            ]
          }
        },
        err => {
          if (err) {
            console.log(err);
            return;
          }
          Quagga.start();
          Quagga.onDetected(results => {
            const codeResult = results.codeResult.code;

            this.setState({
              code: codeResult,
              isScannerActive: false
            });

            // TODO: Close camera on succesful barcode read, bring up info.
            // TODO: Add "scan" button for user to initiate scan
            // TODO: Make graphql request with code, return marvel stored comic data.
          });
        }
      );
    }
  }

  componentWillUnmount() {
    Quagga.stop();
  }

  toggleScanner = () =>
    this.setState({ isScannerActive: !this.state.isScannerActive });

  render() {
    const { toggleScanner } = this;
    const { isScannerActive, code } = this.state;

    return (
      <>
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
          <button className="barcodeReaderStart" onClick={toggleScanner}>
            Start Scanning
          </button>
        )}
        <div className="barcodeResult">{code}</div>
      </>
    );
  }
}
