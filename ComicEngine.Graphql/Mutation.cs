using System.Threading.Tasks;
using ComicEngine.Api.Client;
using ComicEngine.Common.Comic;
using ComicEngine.Graphql.Types;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql {
    public class Mutation {
        private readonly ILogger _logger;

        private IComicHttpRepository _comicHttpApiService;

        public Mutation (ILogger<Mutation> logger, IComicHttpRepository comicHttpApiService) {
            _logger = logger ??
                throw new System.ArgumentNullException (nameof (logger));
            _comicHttpApiService = comicHttpApiService ??
                throw new System.ArgumentNullException (nameof (comicHttpApiService));
        }

        public async Task<Comic> CreateSavedComic (IResolverContext context)
        {
            var token = IdentityTokenSupport
                .ResolveIdentityToken(context.ContextData["HttpContext"] 
                    as HttpContext);
            var comicInput = context.Argument<Comic> ("comic");

            if (comicInput is null) {
                throw new System.ArgumentNullException (nameof (comicInput));
            }

            _logger.LogDebug ("Executing mutation with comic titled: {title}", comicInput.Title);

            Comic response = await _comicHttpApiService.SaveComicToApi (comicInput);

            return response;
        }
    }
}