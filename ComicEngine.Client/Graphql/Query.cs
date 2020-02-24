using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Client.ComicEngineApi;
using ComicEngine.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Client.Graphql {
    public class Query {

        private readonly ILogger _logger;

        private IComicEngineApiService _comicApiService;

        public Query (ILogger<Query> logger, IComicEngineApiService comicApiService) {
            _logger = logger;
            _comicApiService = comicApiService;
        }

        public async Task<Comic> ComicByUpc (string upc) {
            _logger.LogDebug ("Executing query with parameter: {param}", upc);

            // todo: Add exception handling / custom errors.
            string parameters = $"upc={upc}";
            Comic response = await _comicApiService.RequestComicByParameters (parameters);

            return response;
        }

        public async Task<IList<Comic>> ComicsByTitleAndIssueNumber (
            string title,
            string issueNumber
        ) {
            _logger.LogDebug ("Executing ComicByTitleAndIssueNumber with parameters: {title}, {issueNumber}",
                title,
                issueNumber
            );

            // todo: Add exception handling / custom errors.
            string parameters = $"title={title}&issueNumber={issueNumber}";
            var response = await _comicApiService.RequestComicsByParameters (
                parameters,
                "/search"
            );

            return response;
        }

        public async Task<IEnumerable<Comic>> SavedComics () {
            var response = await _comicApiService.RequestAllSavedComics ();

            return response;
        }
    }
}