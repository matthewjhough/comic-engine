using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.Server.Actions.UserComics;
using ComicEngine.Api.Server.UserComics.CreateUserComic.Observers;
using ComicEngine.Api.Server.UserComics.CreateUserComic.States;
using ComicEngine.Data.UserComics;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.StorageContainers;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.Server.UserComics.CreateUserComic
{
    public class CreateUserComicAction : ICreateUserComicAction
    {
        internal IUserComicsRepository UserComicsRepository;

        internal CreateUserComicAction()
        {
        }

        public async Task<UserComic> CreateUserComicAsync (
            Comic comic, 
            StorageContainer storageContainer, 
            string subject)
        {
            // TODO: Error handling
            var userComicState = new CreateUserComicState
            {
                InputComic = comic,
                InputStorageContainer = storageContainer,
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