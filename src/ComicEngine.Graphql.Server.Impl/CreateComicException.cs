using System;

namespace ComicEngine.Graphql.Server.Impl
{
    public class CreateComicException : Exception
    {
        public CreateComicException(string message) : base(message)
        {
        }
    }
}