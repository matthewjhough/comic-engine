using System;
using System.Threading.Tasks;
using Automatonymous;
using GreenPipes;

namespace ComicEngine.State
{
    public abstract class BaseActivity<T, T2> : Activity<T, T2>
    {
        public virtual void Probe(ProbeContext context)
        {
            context.CreateScope("baseScope");
        }

        public virtual void Accept(StateMachineVisitor visitor)
        {
        }

        public virtual Task Execute(BehaviorContext<T, T2> context, Behavior<T, T2> next)
        {
            throw new NotImplementedException();
        }

        public virtual Task Faulted<TException>(
            BehaviorExceptionContext<T, T2, TException> context,
            Behavior<T, T2> next) where TException : Exception
        {
            return next.Faulted(context);
        }
    }
}