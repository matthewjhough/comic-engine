export const ApplicationName = 'ComicEngine.Graphql';

export const QueryParameterNames = {
  ReturnUrl: 'returnUrl',
  Message: 'message'
};

export const LogoutActions = {
  LogoutCallback: 'logout-callback',
  Logout: 'logout',
  LoggedOut: 'logged-out'
};

export const LoginActions = {
  Login: 'login',
  LoginCallback: 'login-callback',
  LoginFailed: 'login-failed',
  Profile: 'profile',
  Register: 'register'
};

const idpBaseRoute = 'https://localhost:7001';

export const ApplicationPaths = {
  DefaultLoginRedirectPath: '/',
  ApiAuthorizationClientConfigurationUrl: `${idpBaseRoute}/.well-known/openid-configuration/`,
  ApiAuthorizationPrefix: '',
  LoginIdpRoute: `https://localhost:7001/connect/authorize`,
  Login: `/${LoginActions.Login}`,
  LoginFailed: `/${LoginActions.LoginFailed}`,
  LoginCallback: `/${LoginActions.LoginCallback}`,
  Register: `/${LoginActions.Register}`,
  Profile: `/${LoginActions.Profile}`,
  LogOut: `/${LogoutActions.Logout}`,
  LoggedOut: `/${LogoutActions.LoggedOut}`,
  LogOutCallback: `/${LogoutActions.LogoutCallback}`,
  // IdentityRegisterPath: '/Identity/Account/Register',
  // IdentityManagePath: '/Identity/Account/Manage'
};
