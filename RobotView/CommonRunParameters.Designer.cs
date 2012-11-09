namespace RobotView
{
    partial class CommonRunParameters
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.speedNumeric = new System.Windows.Forms.NumericUpDown();
            this.accelerationNumeric = new System.Windows.Forms.NumericUpDown();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.Text = "Common Run Parameters";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.Text = "Speed (+ mm/s)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.Text = "Acceleration (+ mm/s^2)";
            // 
            // speedNumeric
            // 
            this.speedNumeric.Location = new System.Drawing.Point(218, 16);
            this.speedNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speedNumeric.Name = "speedNumeric";
            this.speedNumeric.Size = new System.Drawing.Size(100, 24);
            this.speedNumeric.TabIndex = 5;
            this.speedNumeric.ValueChanged += new System.EventHandler(this.speedNumeric_ValueChanged);
            // 
            // accelerationNumeric
            // 
            this.accelerationNumeric.Location = new System.Drawing.Point(218, 53);
            this.accelerationNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.accelerationNumeric.Name = "accelerationNumeric";
            this.accelerationNumeric.Size = new System.Drawing.Size(100, 24);
            this.accelerationNumeric.TabIndex = 6;
            this.accelerationNumeric.ValueChanged += new System.EventHandler(this.accelerationNumeric_ValueChanged);
            // 
            // CommonRunParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.accelerationNumeric);
            this.Controls.Add(this.speedNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Name = "CommonRunParameters";
            this.Size = new System.Drawing.Size(350, 88);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown speedNumeric;
        private System.Windows.Forms.NumericUpDown accelerationNumeric;

    }
}
