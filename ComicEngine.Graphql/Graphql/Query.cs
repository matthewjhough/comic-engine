using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using ComicEngine.Graphql.ComicEngineApi;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Graphql.Graphql {
    public class Query {
        private readonly ILogger _logger;

        private IComicEngineApiService _comicApiService;

        public Query (ILogger<Query> logger, IComicEngineApiService comicApiService) {
            _logger = logger;
            _comicApiService = comicApiService;
        }

        public async Task<Comic> ComicByUpc (string upc) {
            _logger.LogDebug ("Executing query with parameter: {param}", upc);

            Comic response = await _comicApiService.RequestMarvelComicByUpc (upc);

            return response;
        }

        public async Task<IEnumerable<Comic>> ComicsByTitleAndIssueNumber (string title, string issueNumber) {
            _logger.LogDebug ("Executing ComicByTitleAndIssueNumber with parameters: {title}, {issueNumber}", title, issueNumber);

            IEnumerable<Comic> response = await _comicApiService.RequestMarvelComicsByParameters (title, issueNumber);

            return response;
        }

        public async Task<IEnumerable<Comic>> SavedComics () {
            IEnumerable<Comic> response = await _comicApiService.RequestAllSavedComics ();

            return response;
        }
    }
}