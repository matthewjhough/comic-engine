import React, { Component, Fragment } from 'react';
import {NavItem, NavLink} from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from '../Authorization/AuthorizeService';
import { ApplicationPaths } from '../Authorization/ApiAuthorizationConstants';
import IdentityTokenManager from "../Authorization/IdentityTokenManager";
import {routeConfig} from "./routeConfig";
const identityTokenManager = new IdentityTokenManager();

export class LoginMenu extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false,
      userName: null
    };
  }

  componentDidMount() {
    this._subscription = authService.subscribe(() => this.populateState());
    // Load state after url has been parsed, and stored in local storage.
    console.log("LoginMenu:: mounted, processing identity token")
    identityTokenManager
      .ProcessIdentityToken()
      .then(res => {
        this.populateState();
      });
  }

  componentWillUnmount() {
    authService.unsubscribe(this._subscription);
  }

  async populateState() {
    await Promise.all([
      authService.isAuthenticated(),
      authService.getUser()
    ]).then(([isAuthenticated, user]) => {
      this.setState({
        isAuthenticated,
        userName: user && user.name
      }, () => {
        console.log("LoginMenu:: authenticated.", this.state);
      });
    });
  }

  render() {
    const { isAuthenticated, userName } = this.state;
    console.log("LoginMenu:: rendering, isAuthenticated: ", isAuthenticated)
    if (!isAuthenticated) {
      const registerPath = `${ApplicationPaths.Register}`;
      const loginPath = `${ApplicationPaths.Login}`;
      return this.anonymousView(registerPath, loginPath);
    } else {
      const profilePath = `${ApplicationPaths.Profile}`;
      const logoutPath = {
        pathname: `${ApplicationPaths.LogOut}`,
        state: { local: true }
      };
      return this.authenticatedView(userName, profilePath, logoutPath);
    }
  }

  authenticatedView(userName, profilePath, logoutPath) {
    return (
      <Fragment>
        <NavItem>
          <NavLink
              tag={Link}
              to={routeConfig.comicSearch.url}>
            {routeConfig.comicSearch.text}
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink
              tag={Link}
              to={routeConfig.myComics.url}>
            {routeConfig.myComics.text}
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} to={profilePath}>
            My Profile
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} to={logoutPath}>
            Logout
          </NavLink>
        </NavItem>
      </Fragment>
    );
  }

  // TODO: Add register link.
  anonymousView(registerPath, loginPath) {
    return (
      <Fragment>
        <NavItem>
          <NavLink tag={Link} to={registerPath}>
            Register
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} to={loginPath}>
            Login
          </NavLink>
        </NavItem>
      </Fragment>
    );
  }
}
