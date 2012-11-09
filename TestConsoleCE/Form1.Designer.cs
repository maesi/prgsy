namespace TestConsoleCE
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
            this.consoleView1 = new RobotView.ConsoleView();
            this.consoleView2 = new RobotView.ConsoleView();
            this.SuspendLayout();
            // 
            // consoleView1
            // 
            this.consoleView1.BackColor = System.Drawing.Color.Black;
            this.consoleView1.Location = new System.Drawing.Point(3, 3);
            this.consoleView1.Name = "consoleView1";
            this.consoleView1.RobotConsole = null;
            this.consoleView1.Size = new System.Drawing.Size(210, 50);
            this.consoleView1.TabIndex = 0;
            // 
            // consoleView2
            // 
            this.consoleView2.BackColor = System.Drawing.Color.Black;
            this.consoleView2.Location = new System.Drawing.Point(3, 59);
            this.consoleView2.Name = "consoleView2";
            this.consoleView2.RobotConsole = null;
            this.consoleView2.Size = new System.Drawing.Size(210, 50);
            this.consoleView2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(224, 120);
            this.Controls.Add(this.consoleView1);
            this.Controls.Add(this.consoleView2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        private RobotView.ConsoleView consoleView1;
        private RobotView.ConsoleView consoleView2;
        #endregion

    }
}