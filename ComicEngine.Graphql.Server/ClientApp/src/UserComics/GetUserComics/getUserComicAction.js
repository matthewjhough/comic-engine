import {comicEngineUserManager} from "../../Authorization/ComicEngineUserManager";
import {makeGraphqlRequest} from "../../graphqlClient/graphqlClient";
import {setResults, toggleLoading} from "../../ComicResults/comicResultsActions";
import {getUserComicsQuery} from "./getUserComicsQuery";

export function getUserComics() {
    return function(dispatch) {
        return comicEngineUserManager.getUser().then(user => {
            console.action("userComicsActions:: Current user subject: ", user.profile.sub);

            return makeGraphqlRequest(getUserComicsQuery, {
                userId: user.profile.sub
            })
                .then(res => res.json())
                .then(({ data, errors }) => {
                    if (errors && errors.length > 0) {
                        return dispatch(setResults({ results: [] }));
                    }

                    if (data.userComics == null) {
                        return dispatch(setResults({ results: [] }));
                    }

                    return dispatch(setResults({ results: data.userComics }));
                })
                .then(() => dispatch(toggleLoading(false)))
        });
    };
}