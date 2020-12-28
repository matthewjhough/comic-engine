using System;
using System.Threading.Tasks;
using Automatonymous;
using GreenPipes.Util;

namespace ComicEngine.State
{
    public class BaseStateObserver<T> : StateObserver<T>
    {
        public Task StateChanged(
            InstanceContext<T> context, 
            Automatonymous.State currentState, 
            Automatonymous.State previousState)
        {
            string previous = previousState != null ? previousState.Name : "null";
            string current = currentState.Name;
            Console.WriteLine($"=>State Transition from '{previous}' to '{current}'");

            return TaskUtil.Completed;
        }
    }
}