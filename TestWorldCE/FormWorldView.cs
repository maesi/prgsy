using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotView;
using RobotCtrl;

namespace TestWorldCE
{
    public partial class FormWorldView : Form
    {
        public ViewPort ViewPort
        {
            get
            {
                return this.worldView1.ViewPort;
            }
            set
            {
                this.worldView1.ViewPort = value;
            }
        }
        public FormWorldView()
        {
            InitializeComponent();
        }

        public void SaveImage()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SaveImage));
            }
            else
            {
                string _filename = "screen.bmp";
                if (Constants.IsWinCE)
                {
                    _filename = "\\CompactFlash\\FtpRoot\\screen.bmp";
                }
                this.worldView1.SaveImage(_filename);
            }
        }
    }
}