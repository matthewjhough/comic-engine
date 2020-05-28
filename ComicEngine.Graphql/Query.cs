using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.Client;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http;
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

        public async Task<IEnumerable<Comic>> SavedComics (IResolverContext context)
        {
            // var token = IdentityTokenSupport.ResolveIdentityToken(context.ContextData["HttpContext"] as HttpContext);
            var httpContext = context.ContextData["HttpContext"] as HttpContext;
            IEnumerable<Comic> response = await _comicRepository.RequestAllSavedComics ();

            return response;
        }
    }
}