import {comicEngineUserManager} from "./ComicEngineUserManager";
import authService from "./AuthorizeService";

/**
 * Helper class for processing and populating the usermanager's user info.
 */
export default class IdentityTokenManager {
    ProcessIdentityToken =  async () => {
        let user;
        if (window.location.hash) {
            user = await this.ParseFragments();
        }
        
        return user;
    }
    
    ParseFragments = async () => {
        const url = window.location.href;
        return await comicEngineUserManager
            .signinCallback(url)
            .then(user => {
                console.log("IdentityTokenManager:: completing sign in...");
                authService.updateState(user);
                authService.completeSignIn(url);
                console.log("IdentityTokenManager:: sign in complete.");
                window.location.hash = "";
                return user;
            });
    }
}
