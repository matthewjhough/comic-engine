import React, { Component } from 'react';
import { NavMenu } from '../Navigation/NavMenu';
import styles from "./Layout.module.scss"
import {Nav, Navbar, NavbarBrand, NavItem, NavLink} from "reactstrap";
import {slide as Menu} from "react-burger-menu";
import {Link} from "react-router-dom";
import {LoginMenu} from "../Navigation/LoginMenu";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <>
      <div className="mobile-menu">
          <Menu pageWrapId="page-wrap"  outerContainerId="root">
              <Nav className="mr-auto" navbar>
                  <NavItem>
                      <NavLink tag={Link} to="/">
                          Home
                      </NavLink>
                  </NavItem>
                  <LoginMenu />
              </Nav>
          </Menu>
      </div>
        <NavMenu />
        <div className={styles.layoutMain} id="page-wrap">
          {this.props.children}
        </div>
      </>
    );
  }
}
