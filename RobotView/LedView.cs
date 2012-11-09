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
    public partial class LedView : UserControl
    {
        private Led led;
        private bool ledEnabled;
 
        public Led Led
        {
            get
            {
                return led;
            }
            set
            {
                led = value;
                if (led != null)
                {
                    led.LedStateChanged += new EventHandler<LedEventArgs>(ledStateChanged);
                }
            }
        }

        public bool LedEnabled
        {
            get
            {
                return ledEnabled;
            }
            set
            {
                ledEnabled = value;
                updateUI();
            }
        }
        
        public LedView()
        {
            InitializeComponent();
            updateUI();
        }

        void ledStateChanged(object sender, LedEventArgs e)
        {
            LedEnabled = led.LedEnabled;
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
            if (LedEnabled)
            {
                pictureBoxLed.Image = Resource.LedOn;
            }
            else
            {
                pictureBoxLed.Image = Resource.LedOff;
            }
        }
    }
}
