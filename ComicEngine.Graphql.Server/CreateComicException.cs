using System;

namespace ComicEngine.Graphql.Server
{
    public class CreateComicException : Exception
    {
        public CreateComicException(string message) : base(message)
        {
        }
    }
}