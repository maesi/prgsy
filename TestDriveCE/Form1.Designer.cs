namespace TestDriveCE
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
            this.commonRunParameters1 = new RobotView.CommonRunParameters();
            this.driveView1 = new RobotView.DriveView();
            this.runLine1 = new RobotView.RunLine();
            this.SuspendLayout();
            // 
            // commonRunParameters1
            // 
            this.commonRunParameters1.Location = new System.Drawing.Point(3, 309);
            this.commonRunParameters1.Name = "commonRunParameters1";
            this.commonRunParameters1.Size = new System.Drawing.Size(350, 87);
            this.commonRunParameters1.TabIndex = 1;
            // 
            // driveView1
            // 
            this.driveView1.Drive = null;
            this.driveView1.Location = new System.Drawing.Point(3, 3);
            this.driveView1.Name = "driveView1";
            this.driveView1.Size = new System.Drawing.Size(290, 300);
            this.driveView1.TabIndex = 0;
            // 
            // runLine1
            // 
            this.runLine1.Drive = null;
            this.runLine1.Location = new System.Drawing.Point(3, 389);
            this.runLine1.Name = "runLine1";
            this.runLine1.Size = new System.Drawing.Size(350, 54);
            this.runLine1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(467, 481);
            this.Controls.Add(this.runLine1);
            this.Controls.Add(this.commonRunParameters1);
            this.Controls.Add(this.driveView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.DriveView driveView1;
        private RobotView.CommonRunParameters commonRunParameters1;
        private RobotView.RunLine runLine1;
    }
}

