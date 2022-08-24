using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork
{
    public class AsyncCaller
    {
        private EventHandler handler;

        public AsyncCaller(EventHandler handler)
        {
            handler = handler;
        }

        public bool Invoke(int milliseconds, object sender, EventArgs args)
        {
            var task = Task.Factory.StartNew(() => handler.Invoke(sender, args));

            return task.Wait(milliseconds);
        }

    }
}
