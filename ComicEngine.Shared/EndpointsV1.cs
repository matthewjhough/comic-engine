namespace ComicEngine.Shared
{
    public static class EndpointsV1
    {
        // Marvel Comics
        public const string MarvelComicsSearchEndpoint = "v1/marvel/comic/search";
        public const string MarvelComicsUpcEndpoint = "v1/marvel/comic/upc";
        // User Comics
        public const string UserComicsEndpointBase = "v1/user/comics";
        public const string UserComicsEndpoint = "v1/user/comics/{userId}";
        public const string UserComicsDeleteEndpoint = "v1/user/comics/{userId}/comic/{userComicId}";
        // Storage Containers
        public const string StorageContainerEndpointBase = "v1/user/storageContainer";
    }
}