namespace ComicEngine.Api.Client
{
    public static class EndpointsV1
    {
        public const string UserComicsEndpointBase = "v1/user/comics";
        public const string UserComicsEndpoint = "v1/user/comics/{userId}";
        public const string MarvelComicsSearchEndpoint = "v1/marvel/comic/search";
        public const string MarvelComicsUpcEndpoint = "v1/marvel/comic/upc";
    }
}