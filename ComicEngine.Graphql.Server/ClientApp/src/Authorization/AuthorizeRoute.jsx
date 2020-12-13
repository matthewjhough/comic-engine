import React from 'react'
import { Component } from 'react'
import { Route } from 'react-router-dom'
import authService from './AuthorizeService'

export default class AuthorizeRoute extends Component {
    constructor(props) {
        super(props);
        this.state = {
            ready: false,
            authenticated: false
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.authenticationChanged());
        this.populateAuthenticationState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    render() {
        const { ready, authenticated } = this.state;
        if (!ready) {
            return <div/>;
        } else {
            const { component: Component, ...rest } = this.props;
            return <Route {...rest}
                render={(props) => {
                    if (authenticated) {
                        return <Component {...props} />
                    } else {
                        console.log('AuthorizeRoute:: redirecting to idp, due to authentication: ', authenticated)
                        authService.redirectToIdp();
                        return <></>
                    }
                }} />
        }
    }

    async populateAuthenticationState() {
        console.log("AuthorizeRoute:: populating authentication state...");
        const authenticated = await authService.isAuthenticated();
        console.log("AuthorizeRoute:: authentication state populated. authenticated: ", authenticated);
        this.setState({ ready: true, authenticated });
    }

    async authenticationChanged() {
        this.setState({ ready: false, authenticated: false });
        await this.populateAuthenticationState();
    }
}
