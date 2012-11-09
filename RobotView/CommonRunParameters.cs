using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RobotView
{
    public partial class CommonRunParameters : UserControl
    {
        public event EventHandler SpeedChanged;
        public event EventHandler AccelerationChanged;        

        public CommonRunParameters()
        {
            InitializeComponent();

        }

        private void speedNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (SpeedChanged != null)
            {
                SpeedChanged(sender, e);
            }
        }

        private void accelerationNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (AccelerationChanged != null)
            {
                AccelerationChanged(sender, e);
            }

        }
    }
}
