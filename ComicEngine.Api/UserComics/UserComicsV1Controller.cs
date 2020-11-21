using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Client;
using ComicEngine.Api.Commands.UserComics;
using ComicEngine.Common.Comics;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.UserComics {
    [ApiController]
    [Authorize]
    public class UserComicsV1Controller : ControllerBase {
        private readonly ICreateUserComicCommand _createCommand;
        private readonly IGetUserComicCommand _getCommand;
        private readonly ILogger _logger;

        public UserComicsV1Controller (
            ICreateUserComicCommand createUserComicsCommand,
            IGetUserComicCommand getUserComicsCommand,
            ILogger<UserComicsV1Controller> logger
        ) {
            _createCommand = createUserComicsCommand;
            _getCommand = getUserComicsCommand;
            _logger = logger;
        }

        [HttpPost (EndpointsV1.UserComicsEndpoint)]
        public async Task<Comic> Create ([FromBody] Comic comic, [FromRoute] string userId) {
            // TODO: Validation
            if (comic.Title is null) {
                throw new Exception ("Title is required.");
            }
            
            _logger.LogDebug ("**** Comic from body title: {title} ****", comic.Title);
            
            // Todo: add logging/exception handling
            var userComic = await _createCommand.CreateUserComicAsync (comic, userId);

            return userComic;
        }

        [Authorize]
        [HttpGet (EndpointsV1.UserComicsEndpoint)]
        public async Task<IEnumerable<Comic>> Get ([FromRoute] string userId)
        {
            _logger.LogDebug("Retrieving comics for user '{userId}'", userId);
            var test = HttpContext;
            // Todo: add logging / exception handling
            var comicList = await _getCommand.GetUserComics (userId);
            var comicEnumeration = comicList as Comic[] ?? comicList.ToArray();
            _logger.LogDebug("Found '{comicCount}' comics for user '{userId}'", comicEnumeration.Count(), userId);
            
            return comicEnumeration;
        }
    }
}