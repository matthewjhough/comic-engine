import { combineReducers, createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { comicSearchFormReducer } from './ComicSearchForm/comicSearchFormReducer';
import { comicResultsReducer } from './ComicResults/comicResultsReducer';

export const combinedReducers = combineReducers({
  comicSearchForm: comicSearchFormReducer,
  comicResults: comicResultsReducer
});

export const store = createStore(combinedReducers, applyMiddleware(thunk));
