using System;
using Devenlab.Common.Interfaces;

namespace Devenlab.Common.Patterns
{
    public abstract class BaseBusinessProcessManager : IBusinessProcessManager
    {
        public event EventHandler<ProcessEventArgs> OnBeforeProcessEventArgs;

        public event EventHandler<ProcessEventArgs> OnAfterProcessEventArgs;

        public event EventHandler<ProcessEventArgs> OnProcessEventArgs;

        public event EventHandler<ProcessErrorEventArgs> OnProcessErrorEventArgs;

        public void Process()
        {
            try
            {
                OnBeforeProcess(new ProcessEventArgs());
                OnProcess(new ProcessEventArgs());
                OnAfterProcess(new ProcessEventArgs());
            }
            catch (Exception err)
            {
                OnErrorProcess(new ProcessErrorEventArgs(err));
            }
        }

        protected virtual void OnErrorProcess(ProcessErrorEventArgs e)
        {
            EventHandler<ProcessErrorEventArgs> handler = OnProcessErrorEventArgs;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnBeforeProcess(ProcessEventArgs e)
        {
            EventHandler<ProcessEventArgs> handler = OnBeforeProcessEventArgs;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        protected virtual void OnAfterProcess(ProcessEventArgs e)
        {
            EventHandler<ProcessEventArgs> handler = OnAfterProcessEventArgs;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnProcess(ProcessEventArgs e)
        {
            EventHandler<ProcessEventArgs> handler = OnProcessEventArgs;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }
}
