namespace ComicEngine.Identity.Client
{
    public class TokenClientSettings
    {
        public string ClientId { get; set; }
        public string ResponseType { get; set; }
        public string Secret { get; set; }
        public string Authority { get; set; }
        public string Scope { get; set; }
        public string Audience { get; set; }
        public bool RequireHttpMetadata { get; set; }
    }
}