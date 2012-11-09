using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class RunLine : UserControl
    {
        public Drive Drive { get; set; }
        public float Speed { get; set; }
        public float Acceleration { get; set; }

        public RunLine()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            float length = (float)this.lengthNumeric.Value;
            if (!this.cbxSign.Checked)
            {
                length *= -1;
            }
            if (Speed != 0 && Acceleration != 0)
            {
//                Drive.RunLine(length/100, Speed, Acceleration);

                Drive.RunArcLeft(2, 56, Speed, Acceleration);
                Drive.RunArcRight(4, 56, Speed, Acceleration);
            }
        }
    }
}
