namespace RobotView
{
    partial class RunLine
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
            this.lengthNumeric = new System.Windows.Forms.NumericUpDown();
            this.cbxSign = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.Text = "RunLine";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.Text = "Length (+/- mm)";
            // 
            // lengthNumeric
            // 
            this.lengthNumeric.Location = new System.Drawing.Point(177, 16);
            this.lengthNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.lengthNumeric.Name = "lengthNumeric";
            this.lengthNumeric.Size = new System.Drawing.Size(100, 24);
            this.lengthNumeric.TabIndex = 5;
            this.lengthNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbxSign
            // 
            this.cbxSign.Checked = true;
            this.cbxSign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSign.Location = new System.Drawing.Point(119, 16);
            this.cbxSign.Name = "cbxSign";
            this.cbxSign.Size = new System.Drawing.Size(52, 24);
            this.cbxSign.TabIndex = 10;
            this.cbxSign.Text = "+/-";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(283, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(64, 24);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // RunLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbxSign);
            this.Controls.Add(this.lengthNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Name = "RunLine";
            this.Size = new System.Drawing.Size(350, 54);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown lengthNumeric;
        private System.Windows.Forms.CheckBox cbxSign;
        private System.Windows.Forms.Button btnStart;

    }
}
