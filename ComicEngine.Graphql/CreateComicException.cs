using System;

namespace ComicEngine.Graphql
{
    public class CreateComicException : Exception
    {
        public CreateComicException(string message) : base(message)
        {
        }
    }
}