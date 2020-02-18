import React from 'react';
import './BarcodeScanButton.css';

export function BarcodeScanButton({ isResultDisplaying, ...rest }) {
  const barcodeScanButtonText = isResultDisplaying
    ? 'Scan Another'
    : 'Scan Barcode';
  return (
    <button className="barcodeReaderStart" {...rest}>
      {barcodeScanButtonText}
    </button>
  );
}
