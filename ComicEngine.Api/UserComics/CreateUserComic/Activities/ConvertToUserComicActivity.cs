using System;
using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.UserComics.CreateUserComic.States;
using ComicEngine.Common.Comics;
using ComicEngine.Common.UserComics;
using ComicEngine.State;
using GreenPipes;

namespace ComicEngine.Api.UserComics.CreateUserComic.Activities
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
                UserId = context.Instance.InputSubject
            };
            
            return next.Execute(context);
        }
    }
}