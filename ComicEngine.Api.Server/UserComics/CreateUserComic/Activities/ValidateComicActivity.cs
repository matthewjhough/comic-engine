using System;
using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.Server.UserComics.CreateUserComic.States;
using ComicEngine.Shared.Comics;
using ComicEngine.State;
using GreenPipes;

namespace ComicEngine.Api.Server.UserComics.CreateUserComic.Activities
{
    public class ValidateComicActivity : BaseActivity<CreateUserComicState, Comic>
    {
        public override void Probe(ProbeContext context)
        {
            context.CreateScope("validateComic");
        }

        public override Task Execute(BehaviorContext<CreateUserComicState, Comic> context, Behavior<CreateUserComicState, Comic> next)
        {
            // TODO: Validation of more fields, return validation error response.
            var comic = context.Instance.InputComic;

            if (string.IsNullOrWhiteSpace(comic.Title))
            {
                throw new ArgumentException("Comic title cannot be null.");
            }

            return next.Execute(context);
        }
    }
}