using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestMotorCE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            RunMode runMode = RunMode.Real;
            if (!Constants.IsWinCE)
            {
                runMode = RunMode.Virtual;
            }
            DriveCtrl _driveCtrl = null;
            MotorCtrl _motorCtrlLeft = null;
            MotorCtrl _motorCtrlRight = null;
            if (runMode == RunMode.Real)
            {
                _driveCtrl = new DriveCtrlHW(Constants.IODriveCtrl);
                _motorCtrlLeft = new MotorCtrlHW(Constants.IOMotorCtrlLeft);
                _motorCtrlRight = new MotorCtrlHW(Constants.IOMotorCtrlRight);
            }
            else
            {
                _driveCtrl = new DriveCtrlSim();
                _motorCtrlLeft = new MotorCtrlSim();
                _motorCtrlRight = new MotorCtrlSim();
            }
           


            this.driveCtrlView.DriveCtrl = _driveCtrl;
            this.motorCtrlLeft.MotorCtrl = _motorCtrlLeft;
            this.motorCtrlRight.MotorCtrl = _motorCtrlRight;
        }
    }
}