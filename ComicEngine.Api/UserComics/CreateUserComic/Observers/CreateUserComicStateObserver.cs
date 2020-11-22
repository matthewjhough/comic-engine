using System;
using System.Threading.Tasks;
using Automatonymous;
using ComicEngine.Api.UserComics.CreateUserComic.States;
using GreenPipes.Util;

namespace ComicEngine.Api.UserComics.CreateUserComic.Observers
{
    public class CreateUserComicStateObserver :
        StateObserver<CreateUserComicState>
    {
        public Task StateChanged(InstanceContext<CreateUserComicState> context, State currentState, State previousState)
        {
            string previous = previousState != null ? previousState.Name : "null";
            string current = currentState.Name;
            Console.WriteLine($"=>State Transition from '{previous}' to '{current}'");

            return TaskUtil.Completed;
        }
    }
}