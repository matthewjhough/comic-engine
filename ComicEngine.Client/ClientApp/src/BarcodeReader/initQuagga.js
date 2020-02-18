import Quagga from 'quagga';
import { fetchComicFromBarcode } from './fetchApi';

function throttle(f, t) {
  return function(args) {
    let previousCall = this.lastCall;
    this.lastCall = Date.now();
    if (
      previousCall === undefined || // function is being called for the first time
      this.lastCall - previousCall > t
    ) {
      // throttle time has elapsed
      f(args);
    }
  };
}

const quaggaOnDetected = (results, callback) => {
  console.log(results);
  Quagga.stop();
  // FIXME: Find a better way to prune uneccesary leading zero format.
  const codeResult =
    results.codeResult.code.substr(0, 1) === '0'
      ? results.codeResult.code.substr(1)
      : results.codeResult.code;

  fetchComicFromBarcode(
    codeResult.substr(0, 1) === '0' ? codeResult.substr(1) : codeResult
  )
    .then(res => res.json())
    .then(res => callback && callback(res));
};

export const initQuagga = callback =>
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
              supplements: ['ean_5_reader'] // ['ean_5_reader', 'ean_8_reader']
            }
          }
        ]
      }
    },
    err => {
      if (err) {
        console.error(err);
        return;
      }
      Quagga.start();
      Quagga.onDetected(
        throttle(results => quaggaOnDetected(results, callback), 1500)
      );
    }
  );
