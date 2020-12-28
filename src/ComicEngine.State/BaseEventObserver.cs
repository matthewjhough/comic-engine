using System;
using System.Threading.Tasks;
using Automatonymous;
using GreenPipes.Util;

namespace ComicEngine.State
{
    public class BaseEventObserver<T> : EventObserver<BaseState>
    {
        public Task PreExecute(EventContext<BaseState> context)
        {
            Console.WriteLine($"=>In State '{context.Instance.CurrentState.Name}', received Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PreExecute<T>(EventContext<BaseState, T> context)
        {
            Console.WriteLine($"=>In State '{context.Instance.CurrentState.Name}', received Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PostExecute(EventContext<BaseState> context)
        {
            Console.WriteLine($"=> In State from '{context.Instance.CurrentState.Name}' , after processing Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PostExecute<T>(EventContext<BaseState, T> context)
        {
            Console.WriteLine($"=> In State from '{context.Instance.CurrentState.Name}' , after processing Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task ExecuteFault(EventContext<BaseState> context, Exception exception)
        {
            return TaskUtil.Completed;
        }

        public Task ExecuteFault<T>(EventContext<BaseState, T> context, Exception exception)
        {
            return TaskUtil.Completed;
        }
    }
}