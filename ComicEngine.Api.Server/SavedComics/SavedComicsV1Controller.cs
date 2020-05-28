using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.SavedComic;
using ComicEngine.Common.Comic;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.SavedComics {
    public class SavedComicsV1Controller : ControllerBase {
        private readonly ICreateSavedComicCommand _createCommand;
        private readonly IGetSavedComicCommand _getCommand;
        private readonly ILogger _logger;

        public SavedComicsV1Controller (
            ICreateSavedComicCommand createSavedComicsCommand,
            IGetSavedComicCommand getSavedComicsCommand,
            ILogger<SavedComicsV1Controller> logger
        ) {
            _createCommand = createSavedComicsCommand;
            _getCommand = getSavedComicsCommand;
            _logger = logger;
        }

        [HttpPost ("/v1/saved/comics")]
        public async Task<Comic> Create ([FromBody] Comic comic) {
            var subject = TEMP_GetSubFromIdentityToken(HttpContext);
            // TODO: Validation
            if (comic.Title is null) {
                throw new Exception ("Title is required.");
            }
            
            _logger.LogDebug ("**** Comic from body title: {title} ****", comic.Title);
            
            // Todo: add logging/exception handling
            var saveComic = await _createCommand.CreateSavedComicAsync (comic, subject);

            return saveComic;
        }

        [HttpPost ("/v1/saved/comics/temp")]
        public async Task<Comic> CreateFromBody ([FromBody] Comic comic) {
            var subject = TEMP_GetSubFromIdentityToken(HttpContext);
            _logger.LogDebug ("Comic from body title: {title}", comic.Title);
            
            // Todo: add logging/exception handling
            var saveComic = await _createCommand.CreateSavedComicAsync (comic, subject);

            return saveComic;
        }

        [HttpGet ("/v1/saved/comics")]
        [Authorize]
        public async Task<IEnumerable<Comic>> Get ()
        {
            var subject = TEMP_GetSubFromIdentityToken(HttpContext);
            // Todo: add logging / exception handling
            var comicList = await _getCommand.GetSavedComics (subject);

            return comicList;
        }

        /// <summary>
        /// This is a temporary helper method to parse ID_Tokens.
        /// This will be removed once access tokens are being used via graphql,
        /// and server projects.
        /// </summary>
        /// <param name="httpContext"><see cref="HttpContext"/></param>
        /// <returns></returns>
        private string TEMP_GetSubFromIdentityToken(HttpContext httpContext)
        {
            // TODO: Don't do this here. Eventually this comes from access_token instead.
            var requestToken = httpContext.Request.Headers["Authorization"]
                .ToString()
                .Split(" ")
                [1];
            
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadToken(requestToken) as JwtSecurityToken;
            return jwt.Claims.First(claim => claim.Type == "sub").Value;
        }
    }
}