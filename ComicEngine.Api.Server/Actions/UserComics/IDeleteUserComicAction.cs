using System.Threading.Tasks;

namespace ComicEngine.Api.Server.Actions.UserComics
{
    public interface IDeleteUserComicAction
    {
        Task<bool> DeleteUserComic(string userComicId, string subject);
    }
}