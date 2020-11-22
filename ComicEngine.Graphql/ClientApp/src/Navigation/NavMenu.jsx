import React, { Component } from 'react';
import {
  Nav,
  Navbar,
  NavbarBrand,
  NavItem,
  NavLink
} from 'reactstrap';
import { Link } from 'react-router-dom';
import { routeConfig } from './routeConfig';
import './NavMenu.css';
import {LoginMenu} from "./LoginMenu";

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar color="light" light expand="md">
            <NavbarBrand href="/">
              ComicEngine
            </NavbarBrand>
            <Nav className="mr-auto" navbar>
              <NavItem>
                <NavLink tag={Link} to="/">
                  Home
                </NavLink>
              </NavItem>
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
              <LoginMenu />
            </Nav>
        </Navbar>
      </header>
    );
  }
}
