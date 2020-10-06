import React, { Component, Fragment } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';
import IdentityTokenManager from "./IdentityTokenManager";
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
    identityTokenManager.ProcessIdentityToken().then(res => {
      this.populateState();
    });
  }

  componentWillUnmount() {
    authService.unsubscribe(this._subscription);
  }

  async populateState() {
    const [isAuthenticated, user] = await Promise.all([
      authService.isAuthenticated(),
      authService.getUser()
    ]);
    this.setState({
      isAuthenticated,
      userName: user && user.name
    }, () => console.log("authentication status: ", this.state, user));
  }

  render() {
    const { isAuthenticated, userName } = this.state;
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
          <NavLink tag={Link} className="text-dark" to={profilePath}>
            My Profile
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} className="text-dark" to={logoutPath}>
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
          <NavLink tag={Link} className="text-dark" to={registerPath}>
            Register
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} to={loginPath} className="text-dark">
            Login
          </NavLink>
        </NavItem>
      </Fragment>
    );
  }
}
