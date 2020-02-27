namespace ComicEngine.Client.ComicEngineApi.HttpClient {
    /// <summary>
    /// Configuration Object for the current in use ComicHttpClient, This will contain any special 
    /// requirements, as well as the url string to send requests.
    /// </summary>
    public class ComicHttpClientConfig {
        public string ComicHttpClientUrl { get; set; }
    }
}