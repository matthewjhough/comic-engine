import React, { Component } from 'react';
import { ScrollContainer } from '../ScrollContainer/ScrollContainer';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <ScrollContainer>
        <div>
          <h1>Comic Engine App</h1>
          <p>
            Welcome to the comic engine app. You can search for from Marvel, or
            other comic brands, or you can enter in your comic manually to keep
            inventory of it.
          </p>
        </div>
      </ScrollContainer>
    );
  }
}
