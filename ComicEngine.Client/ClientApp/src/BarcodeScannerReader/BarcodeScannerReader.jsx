import React, { Component } from 'react';
import Quagga from 'quagga';
import './BarcodeScannerReader.css';

export class BarcodeScannerReader extends Component {
  state = {
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

            this.setState(
              {
                isScannerActive: false
              },
              () => this.fetchApi(codeResult)
            );
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

  fetchApi = codeResult =>
    fetch('/graphql', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        query: `query($isbn: String){ basicComic(isbn:$isbn) { description isbn issueNumber title } }`,
        variables: {
          isbn: codeResult
        }
      })
    })
      .then(res => res.json())
      .then(({ data }) => {
        const { basicComic } = data;
        this.setState({
          basicComic
        });
      });

  render() {
    const { toggleScanner } = this;
    const { isScannerActive, basicComic } = this.state;

    return (
      <div className="scannerWrapper">
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
            Scan
          </button>
        )}
        <div className="barcodeResult">{basicComic && basicComic.isbn}</div>
      </div>
    );
  }
}
