using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.Server.UserComics.CreateUserComic.States;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;
using ComicEngine.State;
using GreenPipes;

namespace ComicEngine.Api.Server.UserComics.CreateUserComic.Activities
{
    public class ConvertToUserComicActivity : BaseActivity<CreateUserComicState, Comic>
    {
        public override void Probe(ProbeContext context)
        {
            context.CreateScope("convertToUserComic");
        }

        public override Task Execute(
            BehaviorContext<CreateUserComicState, Comic> context, 
            Behavior<CreateUserComicState, Comic> next)
        {
            
            context.Instance.ResultUserComic = new UserComic
            {
                Comic = context.Data,
                // TODO: Validate this storage container exists.
                StorageContainer = context.Instance.InputStorageContainer,
                UserId = context.Instance.InputSubject
            };
            
            return next.Execute(context);
        }
    }
}