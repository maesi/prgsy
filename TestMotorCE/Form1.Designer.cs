namespace TestMotorCE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.driveCtrlView = new RobotView.DriveCtrlView();
            this.motorCtrlLeft = new RobotView.MotorCtrlView();
            this.motorCtrlRight = new RobotView.MotorCtrlView();
            this.SuspendLayout();
            // 
            // driveCtrlView
            // 
            this.driveCtrlView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.driveCtrlView.DriveCtrl = null;
            this.driveCtrlView.Location = new System.Drawing.Point(262, 3);
            this.driveCtrlView.Name = "driveCtrlView";
            this.driveCtrlView.Size = new System.Drawing.Size(480, 75);
            this.driveCtrlView.TabIndex = 0;
            // 
            // motorCtrlLeft
            // 
            this.motorCtrlLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.motorCtrlLeft.Location = new System.Drawing.Point(3, 81);
            this.motorCtrlLeft.MotorCtrl = null;
            this.motorCtrlLeft.Name = "motorCtrlLeft";
            this.motorCtrlLeft.Size = new System.Drawing.Size(480, 330);
            this.motorCtrlLeft.TabIndex = 1;
            // 
            // motorCtrlRight
            // 
            this.motorCtrlRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.motorCtrlRight.Location = new System.Drawing.Point(489, 81);
            this.motorCtrlRight.MotorCtrl = null;
            this.motorCtrlRight.Name = "motorCtrlRight";
            this.motorCtrlRight.Size = new System.Drawing.Size(480, 330);
            this.motorCtrlRight.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(972, 417);
            this.Controls.Add(this.motorCtrlRight);
            this.Controls.Add(this.motorCtrlLeft);
            this.Controls.Add(this.driveCtrlView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.DriveCtrlView driveCtrlView;
        private RobotView.MotorCtrlView motorCtrlLeft;
        private RobotView.MotorCtrlView motorCtrlRight;
    }
}

