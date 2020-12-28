using System.Threading.Tasks;

namespace ComicEngine.Actions.UserComics
{
    public interface IDeleteUserComicAction
    {
        Task<bool> DeleteUserComic(string userComicId, string subject);
    }
}