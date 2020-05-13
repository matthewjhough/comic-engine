using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.Client;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql {
    public class Query {
        private readonly ILogger _logger = ApplicationLogging.CreateLogger (nameof (Query));

        private IComicRepository _comicRepository;

        public Query (IComicRepository comicApiService) {
            _comicRepository = comicApiService ??
                throw new System.ArgumentNullException (nameof (comicApiService));
        }

        public async Task<Comic> ComicByUpc (string upc) {
            _logger.LogDebug ("Executing query with parameter: {param}", upc);

            Comic response = await _comicRepository.RequestMarvelComicByUpc (upc);

            return response;
        }

        public async Task<IEnumerable<Comic>> ComicsByTitleAndIssueNumber (string title, string issueNumber) {
            _logger.LogDebug ("Executing ComicByTitleAndIssueNumber with parameters: {title}, {issueNumber}", title, issueNumber);

            IEnumerable<Comic> response = await _comicRepository.RequestMarvelComicsByParameters (title, issueNumber);

            return response;
        }

        public async Task<IEnumerable<Comic>> SavedComics () {
            IEnumerable<Comic> response = await _comicRepository.RequestAllSavedComics ();

            return response;
        }
    }
}