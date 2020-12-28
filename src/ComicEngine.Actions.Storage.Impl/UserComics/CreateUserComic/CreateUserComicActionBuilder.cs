using System;
using ComicEngine.Data.UserComics;

namespace ComicEngine.Actions.Impl.UserComics.CreateUserComic
{
    public class CreateUserComicActionBuilder
    {
        private IUserComicsRepository _userComicsRepository;

        public CreateUserComicActionBuilder()
        {
        }

        public CreateUserComicActionBuilder WithUserComicsRepository(IUserComicsRepository userComicsRepository)
        {
            _userComicsRepository = userComicsRepository 
                ?? throw new ArgumentNullException(nameof(userComicsRepository));
            return this;
        }

        public CreateUserComicAction Build()
        {
            return new CreateUserComicAction
            {
                UserComicsRepository = _userComicsRepository
            };
        }
    }
}