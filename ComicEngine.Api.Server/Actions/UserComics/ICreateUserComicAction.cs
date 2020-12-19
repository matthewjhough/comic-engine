using System.Threading.Tasks;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.StorageContainers;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.Server.Actions.UserComics {
    public interface ICreateUserComicAction {
        Task<UserComic> CreateUserComicAsync (
            Comic comic, 
            StorageContainer storageContainer, 
            string subject);
    }
}