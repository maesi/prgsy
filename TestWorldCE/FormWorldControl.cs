using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;


namespace TestWorldCE
{
    public partial class FormWorldControl : Form
    {
        private FormWorldView fww;

        public FormWorldControl()
        {
            InitializeComponent();
            
            RunMode runMode = RunMode.Real;
            if (!Constants.IsWinCE)
            {
                runMode = RunMode.Virtual;
            }

            Robot _robot = new Robot(runMode);
            Drive _drive = _robot.Drive;
            _drive.Power = true;
            _drive.Position = new PositionInfo(0, 0, 90);
            _robot.Color = Color.Red;

            World.Robot = _robot;

            driveView1.Drive = _drive;

            _robot.RobotConsole.SwitchChanged += new EventHandler(robotConsole1_SwitchChanged);
            consoleView1.RobotConsole = _robot.RobotConsole;
            
            createWorldView();
        }

        void robotConsole1_SwitchChanged(object sender, EventArgs e)
        {
            SwitchEventArgs _switchEvent = (SwitchEventArgs)e;
            if (_switchEvent.Swi == Switches.Switch2 && _switchEvent.SwitchEnabled)
            {
                fww.SaveImage();
            }
        }

        private void createWorldView()
        {
            // WorldView erstellen und anzeigen
            fww = new FormWorldView();
            fww.ViewPort = new RobotView.ViewPort(-1.25, 1.25, -0.25, 2.25);
            fww.Show();
 
#if !WindowsCE
                this.StartPosition = FormStartPosition.Manual;
                fww.StartPosition = FormStartPosition.Manual;

                World.ObstacleMap = new ObstacleMap(
                    RobotView.Resource.ObstacleMap1, -1.25f, 1.25f, -0.25f, 2.25f);
#endif
            this.Location = new Point(0, 0);
            int width = Math.Min(
            Screen.PrimaryScreen.WorkingArea.Height,
            Screen.PrimaryScreen.WorkingArea.Width - this.Width);
            fww.Width = width;
            fww.ClientSize = new Size(fww.ClientSize.Width, fww.ClientSize.Width);
            fww.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - fww.Width, 0);
        }
    }
}