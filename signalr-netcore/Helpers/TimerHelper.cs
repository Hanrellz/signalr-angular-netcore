using System;
using System.Threading;

namespace signalr_netcore.Helpers
{
    public class TimerHelper
    {
        private Timer Timer;
        private AutoResetEvent AutoResetEvent;
        private Action Action;
        
        public DateTime Started { get; }

        public TimerHelper(Action Action)
        {
            this.Action = Action;
            AutoResetEvent = new AutoResetEvent(false);
            Timer = new Timer(ExecTimer, AutoResetEvent, 1000,2000);
            Started = DateTime.Now;
        }
        
        public void ExecTimer(object stateInfo)
        {
            Action();
 
            if((DateTime.Now - Started).Seconds > 60)
            {
                Timer.Dispose();
            }
        }
    }
}