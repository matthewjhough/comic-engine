using System;
using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.UserComics.CreateUserComic.States;
using ComicEngine.Common.Comics;
using GreenPipes;

namespace ComicEngine.Api.UserComics.CreateUserComic.Activities
{
    public class ValidateComicActivity : Activity<CreateUserComicState, Comic>
    {
        public void Probe(ProbeContext context)
        {
            context.CreateScope("validateComic");
        }

        public void Accept(StateMachineVisitor visitor)
        {
        }

        public Task Execute(BehaviorContext<CreateUserComicState, Comic> context, Behavior<CreateUserComicState, Comic> next)
        {
            // TODO: Validation of more fields, return validation error response.
            var comic = context.Instance.InputComic;

            if (string.IsNullOrWhiteSpace(comic.Title))
            {
                throw new ArgumentException("Comic title cannot be null.");
            }

            return next.Execute(context);
        }

        public Task Faulted<TException>(
            BehaviorExceptionContext<CreateUserComicState, Comic, TException> context, 
            Behavior<CreateUserComicState, Comic> next) 
            where TException : Exception
        {
            return next.Faulted(context);
        }
    }
}