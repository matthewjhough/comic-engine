import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout/Layout';
import { Home } from './Home/Home';
import AuthorizeRoute from './Authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './Authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './Authorization/ApiAuthorizationConstants';

import { BarcodeReader } from './BarcodeReader/BarcodeReader';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <AuthorizeRoute path="/barcode" component={BarcodeReader} />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
      </Layout>
    );
  }
}
