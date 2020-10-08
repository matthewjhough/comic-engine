import {UserManager} from "oidc-client";
import {oidcConfiguration} from "./OidcConfiguration";

export const comicEngineUserManager = new UserManager(oidcConfiguration);