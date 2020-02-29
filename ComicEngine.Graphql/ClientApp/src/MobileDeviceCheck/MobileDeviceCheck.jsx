import React, { Component } from 'react';

export class MobileDeviceCheck extends Component {
  checkIfMobileDevice = () =>
    typeof window.orientation !== 'undefined' ||
    navigator.userAgent.indexOf('IEMobile') !== -1;

  render() {
    const { children } = this.props;
    const { checkIfMobileDevice } = this;
    const isMobileDevice = checkIfMobileDevice();

    return <>{isMobileDevice ? children : ''}</>;
  }
}
