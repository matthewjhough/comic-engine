import { combineReducers, createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { comicSearchFormReducer } from './ComicSearch/comicSearchFormReducer';
import { comicResultsReducer } from './ComicResults/comicResultsReducer';
import { storageContainersReducer } from "./StorageContainers/storageContainerReducer";

export const combinedReducers = combineReducers({
  comicSearchForm: comicSearchFormReducer,
  comicResults: comicResultsReducer,
  storageContainers: storageContainersReducer,
});

export const store = createStore(combinedReducers, applyMiddleware(thunk));
