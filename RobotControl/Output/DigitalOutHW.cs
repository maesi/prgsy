using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    class DigitalOutHW : DigitalOut
    {
        private int Port
        {
            get;
            set;
        }

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

        public DigitalOutHW(int aPort)
        {
            Port = aPort;
        }
    }
}
