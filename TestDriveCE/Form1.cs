using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestDriveCE
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            RunMode runMode = RunMode.Real;
            if (!Constants.IsWinCE)
            {
                runMode= RunMode.Virtual;
            }
            Drive _drive = new Drive(runMode);

            commonRunParameters1.SpeedChanged += new EventHandler(commonRunParameters1_SpeedChanged);
            commonRunParameters1.AccelerationChanged += new EventHandler(commonRunParameters1_AccelerationChanged);

            driveView1.Drive = _drive;
            runLine1.Drive = _drive;
        }

        void commonRunParameters1_AccelerationChanged(object sender, EventArgs e)
        {
            setAcceleration((float)((NumericUpDown)sender).Value);
        }

        void commonRunParameters1_SpeedChanged(object sender, EventArgs e)
        {
            setSpeed((float)((NumericUpDown)sender).Value);
        }

        private void setSpeed(float aSpeed)
        {
            runLine1.Speed = aSpeed;
        }

        private void setAcceleration(float aAcc)
        {
            runLine1.Acceleration = aAcc;
        }
    }
}