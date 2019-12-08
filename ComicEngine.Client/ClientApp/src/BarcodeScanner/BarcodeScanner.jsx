import React, { Component } from 'react';
import Quagga from 'quagga';

export class BarcodeScanner extends Component {
  state = {
    code: ''
  };

  componentDidMount() {
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

          alert(codeResult);

          this.setState({
            code: codeResult
          });

          // TODO: Close camera on succesful barcode read, bring up info.
          // TODO: Add "scan" button for user to initiate scan
          // TODO: Make graphql request with code, return marvel stored comic data.
        });
      }
    );
  }

  componentWillUnmount() {
    Quagga.stop();
  }

  render() {
    const { code } = this.state;

    return (
      <div>
        <p>Point the camera feed below at the barcode.</p>
        <div style={{ maxHeight: 600, width: '100%' }} id="barcode_reader" />
        <div>{code}</div>
      </div>
    );
  }
}
