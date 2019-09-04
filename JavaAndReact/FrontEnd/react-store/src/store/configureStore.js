import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';

import {registerClientReducer} from "../components/Pages/RegisterClient/reducer";
import {loginReducer} from "../components/Pages/Login/reducer";
export default function configureStore (history, initialState) {
    const reducers = {
        registerClient: registerClientReducer,
        login: loginReducer
    };

    const middleware = [
        thunk,
        routerMiddleware(history)
      ];

      const enhancers = [];
      const isDevelopment = process.env.NODE_ENV === 'development';
      if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
        enhancers.push(window.devToolsExtension());
      }

      const rootReducer = combineReducers({
        ...reducers,
        routing: routerReducer
      });

      return createStore(
        rootReducer,
        initialState,
        compose(applyMiddleware(...middleware), ...enhancers)
      );

}