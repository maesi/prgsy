using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestConsoleCE
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

            RobotCtrl.RobotConsole robotConsole1 = new RobotCtrl.RobotConsole(runMode);

            this.consoleView1.RobotConsole = robotConsole1;
            this.consoleView2.RobotConsole = robotConsole1;
        }
    }
}