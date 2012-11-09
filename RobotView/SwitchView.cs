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
    public partial class SwitchView : UserControl
    {
        private Switch swi;
        private bool state;

        public Switch Switch
        {
            get
            {
                return swi;
            }
            set
            {
                swi = value;
                if (value != null)
                {
                    swi.SwitchStateChanged += new EventHandler<SwitchEventArgs>(switchStateChanged);
                }
            }
        }

        public bool State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                updateUI();
            }
        }

        public SwitchView()
        {
            InitializeComponent();
        }


        void switchStateChanged(object sender, SwitchEventArgs e)
        {
            State = swi.SwitchEnabled;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (swi != null)
            {
                swi.SwitchEnabled = !swi.SwitchEnabled;
            }
        }

        private void updateUI()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    updateUIInternal();
                }));
            }
            else
            {
                updateUIInternal();
            }
        }

        private void updateUIInternal()
        {
            if (State)
            {
                pictureBoxSwitch.Image = Resource.SwitchOn;
            }
            else
            {
                pictureBoxSwitch.Image = Resource.SwitchOff;
            }
        }
    }
}
