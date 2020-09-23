import * as React from 'react';
import { Route } from 'react-router';
import Home from './components/Home';
import Layout from './components/Layout';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'
export default class App extends React.Component {
  static displayName = App.name;
  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <AuthorizeRoute path='/counter' component={Counter} />
        <AuthorizeRoute path='/fetch-data/:startDateIndex?' component={FetchData} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}

