using System;
using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.UserComics.CreateUserComic.States;
using GreenPipes.Util;

namespace ComicEngine.Api.UserComics.CreateUserComic.Observers
{
    public class CreateUserComicEventObserver :
        EventObserver<CreateUserComicState>
    {
        public Task PreExecute(EventContext<CreateUserComicState> context)
        {
            Console.WriteLine($"=>In State '{context.Instance.CurrentState.Name}', received Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PreExecute<T>(EventContext<CreateUserComicState, T> context)
        {
            Console.WriteLine($"=>In State '{context.Instance.CurrentState.Name}', received Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PostExecute(EventContext<CreateUserComicState> context)
        {
            Console.WriteLine($"=> In State from '{context.Instance.CurrentState.Name}' , after processing Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PostExecute<T>(EventContext<CreateUserComicState, T> context)
        {
            Console.WriteLine($"=> In State from '{context.Instance.CurrentState.Name}' , after processing Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task ExecuteFault(EventContext<CreateUserComicState> context, Exception exception)
        {
            return TaskUtil.Completed;
        }

        public Task ExecuteFault<T>(EventContext<CreateUserComicState, T> context, Exception exception)
        {
            return TaskUtil.Completed;
        }
    }
}