import { UPDATE_COMIC_BARCODE_RESULT } from './comicsActionTypes';

const defaultState = {};

export function comicsReducer(state = defaultState, action) {
  switch (action.type) {
    case UPDATE_COMIC_BARCODE_RESULT:
      return { ...state, comicBarcodeResult: action.comicBarcodeResult };
    default:
      return state;
  }
}
