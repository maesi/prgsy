using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{
    class DigitalInHW : DigitalIn
    {
        private Timer pollTimer;
        private int Port
        {
            get;
            set;
        }
        private int oldData;
        public override int Data
        {
            get
            {
                return IOPort.Read(Port);
            }
            set
            {
                IOPort.Write(Port, value);
            }
        }

        public DigitalInHW(int aPort)
        {
            Port = aPort;
            oldData = -1;
            initPollTimer();


        }

        private void poll(object state)
        {
            if (oldData != Data)
            {
                oldData = Data;
                OnDigitalInChanged(EventArgs.Empty);
            }
        }

        private void initPollTimer()
        {
            pollTimer = new Timer(new TimerCallback(poll), null, 0, 50);
        }


        public override void Dispose()
        {
            base.Dispose();
            if (pollTimer != null)
            {
                pollTimer.Dispose();
            }
        }
    }
}
