using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Actions.Impl.UserComics.CreateUserComic.States;
using ComicEngine.Data.UserComics;
using ComicEngine.State;
using GreenPipes;

namespace ComicEngine.Actions.Impl.UserComics.CreateUserComic.Activities
{
    public class PersistUserComicActivity : BaseActivity<CreateUserComicState, IUserComicsRepository>
    {
        public override void Probe(ProbeContext context)
        {
            context.CreateScope("persistUserComic");
        }

        public override async Task Execute(
            BehaviorContext<CreateUserComicState, IUserComicsRepository> context, 
            Behavior<CreateUserComicState, IUserComicsRepository> next)
        {
            // TODO: Validate subject id is not null.
            
            await context.Data.CreateUserComic(
                context.Instance.ResultUserComic,
                context.Instance.InputSubject);
        }
    }
}