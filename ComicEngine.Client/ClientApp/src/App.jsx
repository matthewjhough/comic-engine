import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout/Layout';
import { Home } from './Home/Home';
import { FetchData } from './FetchData/FetchData';
import { Counter } from './Counter/Counter';
import AuthorizeRoute from './Authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './Authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './Authorization/ApiAuthorizationConstants';

import './custom.css';
import { BarcodeScanner } from './BarcodeScanner/BarcodeScanner';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/counter" component={Counter} />
        <AuthorizeRoute path="/fetch-data" component={FetchData} />
        <Route path="/barcode" component={BarcodeScanner} />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
      </Layout>
    );
  }
}
