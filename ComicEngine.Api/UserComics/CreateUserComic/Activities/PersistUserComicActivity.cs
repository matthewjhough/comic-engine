using System;
using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.UserComics.CreateUserComic.States;
using GreenPipes;

namespace ComicEngine.Api.UserComics.CreateUserComic.Activities
{
    public class PersistUserComicActivity : Activity<CreateUserComicState, IUserComicsRepository>
    {
        public void Probe(ProbeContext context)
        {
            context.CreateScope("persistUserComic");
        }

        public void Accept(StateMachineVisitor visitor)
        {
        }

        public async Task Execute(
            BehaviorContext<CreateUserComicState, IUserComicsRepository> context, 
            Behavior<CreateUserComicState, IUserComicsRepository> next)
        {
            // TODO: Validate subject id is not null.
            
            await context.Data.CreateUserComic(
                context.Instance.ResultUserComic,
                context.Instance.InputSubject);
        }

        public Task Faulted<TException>(
            BehaviorExceptionContext<CreateUserComicState, IUserComicsRepository, TException> context,
            Behavior<CreateUserComicState, IUserComicsRepository> next) where TException : Exception
        {
            return next.Faulted(context);
        }
    }
}