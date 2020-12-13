import {comicEngineUserManager} from "../../Authorization/ComicEngineUserManager";
import {toggleLoading} from "../../ComicResults/comicResultsActions";
import {makeGraphqlRequest} from "../../graphqlClient/graphqlClient";
import {NotificationManager} from "react-notifications";
import {deleteUserComicMutation} from "./deleteUserComicMutation";
import {getUserComics} from "../GetUserComics/getUserComicAction";

export function deleteUserComic(userComic) {
    const isDeleting = window.confirm(`Are you sure you want to delete ${userComic.comic.title}`);
    
    if (!isDeleting) {
        return function(dispatch) {
            return new Promise(() => 
                console.log("Cancelling delete request for comic: ", userComic.comic.title))
                .then(() => {});
        };
    }
    return function(dispatch) {
        return comicEngineUserManager.getUser().then(user => {
            console.log("userComicsActions:: Current user subject: ", user.profile.sub);
            dispatch(toggleLoading(true));
            console.log("userComicsActions:: Deleting user comic: ", userComic)

            return makeGraphqlRequest(deleteUserComicMutation, {
                userId: user.profile.sub,
                userComicId: userComic.id
            })
                .then(res => res.json())
                .then(json => {
                    console.log("userComicsActions:: JSON returned from comic deletion: ", json);

                    if (json && json.errors) {
                        console.error("userComicsActions:: List of errors from response: ", json.errors);
                        throw "Something went wrong.";
                    }

                    if (json.data && !json.data.deleteUserComic) {
                        NotificationManager.error(
                            'Delete failed.',
                            `${userComic.title} was not removed from My Comics`
                        );
                        throw "Unable to delete comic";
                    }


                    console.log('userComicsActions:: Comic removed from database.', userComic);
                    NotificationManager.success(
                        'Removed',
                        `${userComic.comic.title} removed from My Comics`
                    );

                    return json;
                })
                .then(() => dispatch(getUserComics()));
        })
    }
}