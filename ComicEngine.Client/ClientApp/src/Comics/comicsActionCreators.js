import { UPDATE_COMIC_BARCODE_RESULT } from './comicsActionTypes';

/**
 * Barcode Comic updater method.
 *
 * @param {object} comicBarcodeResult - Comic object returned from graphql
 */
export function updateComicBarcodeResult(comicBarcodeResult) {
  return {
    type: UPDATE_COMIC_BARCODE_RESULT,
    comicBarcodeResult
  };
}
