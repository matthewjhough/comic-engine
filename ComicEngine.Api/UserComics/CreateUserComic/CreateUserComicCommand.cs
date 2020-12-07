using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.Commands.UserComics;
using ComicEngine.Api.UserComics.CreateUserComic.Observers;
using ComicEngine.Api.UserComics.CreateUserComic.States;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.UserComics.CreateUserComic
{
    public class CreateUserComicCommand : ICreateUserComicCommand
    {
        internal IUserComicsRepository UserComicsRepository;

        internal CreateUserComicCommand()
        {
        }

        public async Task<UserComic> CreateUserComicAsync (Comic comic, string subject)
        {
            // TODO: Error handling
            var userComicState = new CreateUserComicState
            {
                InputComic = comic,
                InputSubject = subject
            };
            var userComicResult = await ExecuteStateMachine(userComicState);

            return userComicResult;
        }

        private async Task<UserComic> ExecuteStateMachine(CreateUserComicState createUserComicState)
        {
            var createUserStateMachine = new CreateUserComicStateMachine();

            createUserStateMachine.ConnectStateObserver(new CreateUserComicStateObserver());
            createUserStateMachine.ConnectEventObserver(new CreateUserComicEventObserver());
            
            await createUserStateMachine
                .RaiseEvent(createUserComicState, createUserStateMachine.CreateUserComic);
            await createUserStateMachine
                .RaiseEvent(createUserComicState, createUserStateMachine.ValidateComic, createUserComicState.InputComic);
            await createUserStateMachine
                .RaiseEvent(createUserComicState, createUserStateMachine.ConvertToUserComic, createUserComicState.InputComic);
            await createUserStateMachine
                .RaiseEvent(createUserComicState, createUserStateMachine.CreateAndAddUserComic, UserComicsRepository, createUserComicState.ResultUserComic);
            
            return createUserComicState.ResultUserComic;
        }
    }
}