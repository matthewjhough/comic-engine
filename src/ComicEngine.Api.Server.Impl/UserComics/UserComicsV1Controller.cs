using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Actions.UserComics;
using ComicEngine.Shared;
using ComicEngine.Shared.UserComics;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.Impl.UserComics {
    [ApiController]
    [Authorize]
    public class UserComicsV1Controller : Controller {
        private readonly ICreateUserComicAction _createUserComicAction;
        private readonly IGetUserComicAction _getUserComicAction;
        private readonly IDeleteUserComicAction _deleteUserComicAction;
        private readonly ILogger _logger;

        public UserComicsV1Controller (
            ICreateUserComicAction createUserComicAction,
            IGetUserComicAction getUserComicAction,
            IDeleteUserComicAction deleteUserComicAction,
            ILogger<UserComicsV1Controller> logger
        ) {
            _createUserComicAction = createUserComicAction;
            _getUserComicAction = getUserComicAction;
            _deleteUserComicAction = deleteUserComicAction;
            _logger = logger;
        }

        [HttpPost (EndpointsV1.UserComicsEndpoint)]
        public async Task<UserComic> Create (
            // TODO: CREATE COMIC REQUEST TYPE
            [FromBody] CreateUserComicRequest createUserComicRequest, 
            [FromRoute] string userId) {
            // TODO: Validation
            if (createUserComicRequest.Comic.Title is null) {
                throw new Exception ("Title is required.");
            }
            
            _logger.LogDebug ("**** Comic from body title: {title} ****", 
                createUserComicRequest.Comic.Title);
            
            // Todo: add logging/exception handling
            var userComic = await _createUserComicAction.CreateUserComicAsync (
                createUserComicRequest.Comic, 
                createUserComicRequest.StorageContainer, 
                userId);

            return userComic;
        }

        [Authorize]
        [HttpGet (EndpointsV1.UserComicsEndpoint)]
        public async Task<IEnumerable<UserComic>> Get ([FromRoute] string userId)
        {
            _logger.LogDebug("Retrieving comics for user '{userId}'", userId);
            // Todo: add logging / exception handling
            var comicList = await _getUserComicAction.GetUserComics (userId);
            var comicEnumeration = comicList as UserComic[] ?? comicList.ToArray();
            _logger.LogDebug(
                "Found '{comicCount}' comics for user '{userId}'", 
                comicEnumeration.Count(), 
                userId);
            
            return comicEnumeration;
        }

        [Authorize]
        [HttpDelete(EndpointsV1.UserComicsDeleteEndpoint)]
        public async Task<bool> Delete([FromRoute] string userId, string userComicId)
        {
            var isUserComicDeleted = await _deleteUserComicAction.DeleteUserComic(userComicId, userId);
            
            return isUserComicDeleted;
        }
    }
}