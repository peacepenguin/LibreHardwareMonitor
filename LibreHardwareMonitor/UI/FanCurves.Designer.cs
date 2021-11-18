namespace LibreHardwareMonitor.UI
{
    partial class FanCurves
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FanCurves));
            this.numericUpDown_hysteresis = new System.Windows.Forms.NumericUpDown();
            this.label_hysteresis = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hysteresis)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_hysteresis
            // 
            this.numericUpDown_hysteresis.Location = new System.Drawing.Point(29, 338);
            this.numericUpDown_hysteresis.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_hysteresis.Name = "numericUpDown_hysteresis";
            this.numericUpDown_hysteresis.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_hysteresis.TabIndex = 1;
            this.numericUpDown_hysteresis.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_hysteresis
            // 
            this.label_hysteresis.AutoSize = true;
            this.label_hysteresis.Location = new System.Drawing.Point(29, 305);
            this.label_hysteresis.Name = "label_hysteresis";
            this.label_hysteresis.Size = new System.Drawing.Size(88, 13);
            this.label_hysteresis.TabIndex = 2;
            this.label_hysteresis.Text = "Hysteresis Value:";
            // 
            // FanCurves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_hysteresis);
            this.Controls.Add(this.numericUpDown_hysteresis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FanCurves";
            this.Text = "Fan Curves";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hysteresis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_hysteresis;
        private System.Windows.Forms.Label label_hysteresis;
    }
}
