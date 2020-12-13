import React, { Component } from 'react';
import { NavMenu } from '../Navigation/NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <>
        <NavMenu />
        {this.props.children}
      </>
    );
  }
}
