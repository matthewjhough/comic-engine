import { combineReducers, createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { comicsReducer } from './Comics/comicsReducer';
import { comicSearchFormReducer } from './ComicSearchForm/comicSearchFormReducer';

export const combinedReducers = combineReducers({
  comics: comicsReducer,
  comicSearchForm: comicSearchFormReducer
});

export const store = createStore(combinedReducers, applyMiddleware(thunk));
