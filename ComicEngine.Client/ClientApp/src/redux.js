import { combineReducers, createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { comicsReducer } from './Comics/comicsReducer';

export const combinedReducers = combineReducers({
  comics: comicsReducer
});

export const store = createStore(combinedReducers, applyMiddleware(thunk));
