using System;

namespace ComicEngine.Api.UserComics.CreateUserComic
{
    public class CreateUserComicCommandBuilder
    {
        private IUserComicsRepository _userComicsRepository;

        public CreateUserComicCommandBuilder()
        {
        }

        public CreateUserComicCommandBuilder WithUserComicsRepository(IUserComicsRepository userComicsRepository)
        {
            _userComicsRepository = userComicsRepository 
                ?? throw new ArgumentNullException(nameof(userComicsRepository));
            return this;
        }

        public CreateUserComicCommand Build()
        {
            return new CreateUserComicCommand
            {
                UserComicsRepository = _userComicsRepository
            };
        }
    }
}