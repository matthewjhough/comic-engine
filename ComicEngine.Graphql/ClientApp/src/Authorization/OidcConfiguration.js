import {WebStorageStateStore} from "oidc-client";
import {ApplicationName} from "./ApiAuthorizationConstants";

export const oidcConfiguration = {
    authority: "https://localhost:7001",
    client_id: "ComicEngine.Graphql",
    redirect_uri: "http://localhost:5002",
    response_type: "id_token",
    scope: "openid profile",
    post_logout_redirect_uri: "http://localhost:5002/index.html",
    automaticSilentRenew: true,
    includeIdTokenInSilentRenew: true,
    userStore: new WebStorageStateStore({
        prefix: ApplicationName
    })
}