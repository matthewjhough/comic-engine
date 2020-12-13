import React, { Component } from 'react';
// import { Route } from 'react-router';
import { NotificationContainer } from 'react-notifications';
import { Layout } from './Layout/Layout';
import { Home } from './Home/Home';
import { ApplicationPaths } from './Authorization/ApiAuthorizationConstants';
import AuthorizeRoute from './Authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './Navigation/ApiAuthorizationRoutes';
import { routeConfig } from './Navigation/routeConfig';

import 'react-notifications/lib/notifications.css';
import './custom.css';
import { Route } from "react-router-dom";

export default class App extends Component {
  static displayName = App.name;
  
    render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <AuthorizeRoute
          path={routeConfig.comicSearch.url}
          component={routeConfig.comicSearch.component}
        />
        <AuthorizeRoute
          path={routeConfig.myComics.url}
          component={routeConfig.myComics.component}
        />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
        <NotificationContainer />
      </Layout>
    );
  }
}
