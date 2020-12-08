using System.Threading.Tasks;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.Commands.UserComics
{
    public interface IDeleteUserComicCommand
    {
        Task<bool> DeleteUserComic(string userComicId, string subject);
    }
}