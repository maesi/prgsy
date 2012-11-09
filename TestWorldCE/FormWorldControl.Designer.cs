namespace TestWorldCE
{
    partial class FormWorldControl
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
            this.driveView1 = new RobotView.DriveView();
            this.consoleView1 = new RobotView.ConsoleView();
            this.SuspendLayout();
            // 
            // driveView1
            // 
            this.driveView1.Drive = null;
            this.driveView1.Location = new System.Drawing.Point(0, 0);
            this.driveView1.Name = "driveView1";
            this.driveView1.Size = new System.Drawing.Size(290, 300);
            this.driveView1.TabIndex = 0;
            // 
            // consoleView1
            // 
            this.consoleView1.BackColor = System.Drawing.Color.Black;
            this.consoleView1.Location = new System.Drawing.Point(69, 306);
            this.consoleView1.Name = "consoleView1";
            this.consoleView1.RobotConsole = null;
            this.consoleView1.Size = new System.Drawing.Size(210, 50);
            this.consoleView1.TabIndex = 3;
            // 
            // FormWorldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(334, 366);
            this.Controls.Add(this.consoleView1);
            this.Controls.Add(this.driveView1);
            this.Name = "FormWorldControl";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormWorldControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.DriveView driveView1;
        private RobotView.ConsoleView consoleView1;
    }
}

