import {comicEngineUserManager} from "./ComicEngineUserManager";

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
        const user = await comicEngineUserManager
            .signinCallback(url);
        // TODO: Keep token in cookie?
        // document.cookie = `id_token=${parameters.id_token}`;
        window.location.hash = "";
        return user;
    }
}
