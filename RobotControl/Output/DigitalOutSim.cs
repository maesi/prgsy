using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    class DigitalOutSim : DigitalOut
    {
        public override int Data
        {
            get;
            set;
        }
    }
}
