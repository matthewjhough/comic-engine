import React, { Component } from 'react';
import {
  Nav,
  Navbar,
  NavbarBrand,
  NavItem,
  NavLink
} from 'reactstrap';
import { Link } from 'react-router-dom';
import { slide as Menu } from 'react-burger-menu';
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
          <div className="non-mobile-menu">
            <Nav className="mr-auto" navbar>
              <NavItem>
                <NavLink tag={Link} to="/">
                  Home
                </NavLink>
              </NavItem>
              <LoginMenu />
            </Nav>
          </div>
        </Navbar>
      </header>
    );
  }
}
