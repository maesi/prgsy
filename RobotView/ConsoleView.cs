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
    public partial class ConsoleView : UserControl
    {
        private RobotConsole robotConsole;
        public RobotConsole RobotConsole
        {
            get
            {
                return robotConsole;
            }
            set
            {
                robotConsole = value;
                initViews();
            }
        }

        public ConsoleView()
        {
            InitializeComponent();            
        }

        private void initViews()
        {
            if (RobotConsole != null)
            {
                ledView1.Led = RobotConsole[Leds.Led1];
                ledView2.Led = RobotConsole[Leds.Led2];
                ledView3.Led = RobotConsole[Leds.Led3];
                ledView4.Led = RobotConsole[Leds.Led4];

                switchView1.Switch = RobotConsole[Switches.Switch1];
                switchView2.Switch = RobotConsole[Switches.Switch2];
                switchView3.Switch = RobotConsole[Switches.Switch3];
                switchView4.Switch = RobotConsole[Switches.Switch4];
            }
        }

    }
}
