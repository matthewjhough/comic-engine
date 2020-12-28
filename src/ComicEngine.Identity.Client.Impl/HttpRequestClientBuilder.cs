using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace ComicEngine.Identity.Client.Impl
{
    /// <summary>
    /// Helper class to create an <see cref="HttpRequestClient{T}"/> instance.
    /// </summary>
    public class HttpRequestClientBuilder<T>
    {
        private IHttpContextAccessor HttpContextAccessor { get; set; }
        private Dictionary<string, string> RequestHeaders { get; set; }
        private HttpMethod Method { get; set; }
        private string RequestToken { get; set; }
        private T RequestParameters { get; set; }
        private string RelativeUrl { get; set; }
        private string AbsoluteUrl { get; set; }
        
        private TokenClientSettings TokenClientSettings { get; set; }
        
        public HttpRequestClientBuilder<T> WithAbsoluteUrl(
            string absoluteUrl)
        {
            AbsoluteUrl = absoluteUrl;
            return this;
        }

        public HttpRequestClientBuilder<T> WithTokenClientSettings(TokenClientSettings tokenClientSettings)
        {
            TokenClientSettings = tokenClientSettings;
            return this;
        }

        public HttpRequestClientBuilder<T> WithRelativeUrl(
            string relativeUrl)
        {
            RelativeUrl = relativeUrl;
            return this;
        }

        public HttpRequestClientBuilder<T> WithRequestBody(
            T requestBody)
        {
            RequestParameters = requestBody;
            return this;
        }
        
        public HttpRequestClientBuilder<T> WithRequestToken(
            string requestToken)
        {
            RequestToken = requestToken;
            return this;
        }
        
        public HttpRequestClientBuilder<T> WithRequestMethod(
            HttpMethod requestMethod)
        {
            Method = requestMethod;
            return this;
        }
        
        public HttpRequestClientBuilder<T> WithRequestHeaders(
            Dictionary<string, string> requestHeaders)
        {
            RequestHeaders = requestHeaders;
            return this;
        }

        public HttpRequestClientBuilder<T> WithHttpContextAccessor(
            IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
            return this;
        }

        public HttpRequestClientBuilder<T> WithRequestParametersAsBody()
        {
            // Todo: iterate through request parameters and turn into body format.
            return this;
        }
        
        public HttpRequestClientBuilder<T> WithRequestParametersAsQueryString()
        {
            // Todo: iterate through request parameters and turn into query string.
            return this;
        }

        public HttpRequestClient<T> Build()
        {
            // Todo: validate required parameters
            // Todo: add all methods, add conditionals with what exists, add defaults
            return new HttpRequestClient<T>()
            {
                HttpContextAccessor = HttpContextAccessor,
                AbsoluteUrl = AbsoluteUrl,
                RelativeUrl = RelativeUrl,
                RequestToken = RequestToken,
                RequestBody = RequestParameters,
                RequestHeaders = RequestHeaders,
                Method = Method,
                TokenClientSettings = TokenClientSettings
            };
        }
    }
}