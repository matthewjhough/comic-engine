import React, { Component } from 'react';
import Quagga from 'quagga';
import './BarcodeScannerReader.css';

function debounced(delay, fn) {
  let timerId;
  return function(...args) {
    if (timerId) {
      clearTimeout(timerId);
    }
    timerId = setTimeout(() => {
      fn(...args);
      timerId = null;
    }, delay);
  };
}

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
                  supplements: ['ean_5_reader', 'ean_8_reader'] // 'i2of5_reader',
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
            console.log(results);
            // FIXME: Find a better way to prune uneccesary leading zero format.
            const codeResult =
              results.codeResult.code.substr(0, 1) === '0'
                ? results.codeResult.code.substr(1)
                : results.codeResult.code;
            Quagga.stop();

            const dFetch = debounced(1500, () => {
              return this.fetchApi(
                codeResult.substr(0, 1) === '0'
                  ? codeResult.substr(1)
                  : codeResult
              );
            });
            this.setState(
              {
                isScannerActive: false
              },
              dFetch
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
        query: `query($upc: String){ basicComic(upc:$upc) { description upc issueNumber title } }`,
        variables: {
          upc: codeResult
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
            Scan Barcode
          </button>
        )}
        <div className="barcodeResult">{basicComic && basicComic.title}</div>
      </div>
    );
  }
}
