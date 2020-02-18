import React from 'react';
import styles from './BarcodeScanButton.module.scss';

export function BarcodeScanButton({ isResultDisplaying, ...rest }) {
  const barcodeScanButtonText = isResultDisplaying
    ? 'Scan Another'
    : 'Scan Barcode';
  return (
    <button className={styles.barcodeReaderStart} {...rest}>
      {barcodeScanButtonText}
    </button>
  );
}
