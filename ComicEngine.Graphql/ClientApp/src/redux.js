import { combineReducers, createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { comicsReducer } from './Comics/comicsReducer';
import { comicSearchFormReducer } from './ComicSearchForm/comicSearchFormReducer';
import { comicResultsReducer } from './ComicResults/comicResultsReducer';

export const combinedReducers = combineReducers({
  comics: comicsReducer,
  comicSearchForm: comicSearchFormReducer,
  comicResults: comicResultsReducer
});

export const store = createStore(combinedReducers, applyMiddleware(thunk));
