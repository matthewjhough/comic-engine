import { combineReducers, createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { comicSearchFormReducer } from './ComicSearch/comicSearchFormReducer';
import { comicResultsReducer } from './ComicResults/comicResultsReducer';
import { getStorageContainersReducer } from "./StorageContainers/GetStorageContainers/getStorageContainerReducer";

export const combinedReducers = combineReducers({
  comicSearchForm: comicSearchFormReducer,
  comicResults: comicResultsReducer,
  storageContainers: getStorageContainersReducer,
});

export const store = createStore(combinedReducers, applyMiddleware(thunk));
