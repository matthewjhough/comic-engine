import React from 'react';
import { StickyButton } from '../StickyButton/StickyButton';

export function BarcodeScanButton({ isResultDisplaying, ...rest }) {
  const barcodeScanButtonText = isResultDisplaying
    ? 'Scan Another'
    : 'Scan Barcode';
  return <StickyButton {...rest}>{barcodeScanButtonText}</StickyButton>;
}
