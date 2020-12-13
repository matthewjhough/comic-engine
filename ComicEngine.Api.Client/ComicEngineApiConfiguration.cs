namespace ComicEngine.Api.Client {
    /// <summary>
    /// Configuration Object for the current in use ComicHttpClient, This will contain any special 
    /// requirements, as well as the url string to send requests.
    /// </summary>
    public class ComicEngineApiConfiguration {
        public string ClientBaseUrl { get; set; }
    }
}