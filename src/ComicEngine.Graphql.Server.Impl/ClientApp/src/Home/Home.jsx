import React, { Component } from 'react';
import { AbstractScrollDiv } from '../AbstractScrollDiv/AbstractScrollDiv';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <AbstractScrollDiv>
        <div>
          <h1>Comic Engine App</h1>
          <p>
            Welcome to the comic engine app. You can search for from Marvel, or
            other comic brands, or you can enter in your comic manually to keep
            inventory of it.
          </p>
        </div>
      </AbstractScrollDiv>
    );
  }
}
