import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout/Layout';
import { Home } from './Home/Home';
import AuthorizeRoute from './Authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './Authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './Authorization/ApiAuthorizationConstants';
import { ComicSearch } from './ComicSearch/ComicSearch';

import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <AuthorizeRoute path="/comic-search" component={ComicSearch} />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
      </Layout>
    );
  }
}
