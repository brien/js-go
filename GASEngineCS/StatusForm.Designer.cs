namespace Junction
{
    partial class StatusForm
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
            this.btnStop = new System.Windows.Forms.Button();
            this.cbStopped = new System.Windows.Forms.CheckBox();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.lblFeasible = new System.Windows.Forms.Label();
            this.lblCurrentValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(57, 181);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cbStopped
            // 
            this.cbStopped.AutoSize = true;
            this.cbStopped.Location = new System.Drawing.Point(57, 220);
            this.cbStopped.Name = "cbStopped";
            this.cbStopped.Size = new System.Drawing.Size(66, 17);
            this.cbStopped.TabIndex = 1;
            this.cbStopped.Text = "Stopped";
            this.cbStopped.UseVisualStyleBackColor = true;
            this.cbStopped.Visible = false;
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Location = new System.Drawing.Point(57, 32);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(64, 13);
            this.lblGeneration.TabIndex = 2;
            this.lblGeneration.Text = "Generations";
            // 
            // lblFeasible
            // 
            this.lblFeasible.AutoSize = true;
            this.lblFeasible.Location = new System.Drawing.Point(57, 72);
            this.lblFeasible.Name = "lblFeasible";
            this.lblFeasible.Size = new System.Drawing.Size(137, 13);
            this.lblFeasible.TabIndex = 3;
            this.lblFeasible.Text = "No Feasible Solution Found";
            // 
            // lblCurrentValue
            // 
            this.lblCurrentValue.AutoSize = true;
            this.lblCurrentValue.Location = new System.Drawing.Point(57, 114);
            this.lblCurrentValue.Name = "lblCurrentValue";
            this.lblCurrentValue.Size = new System.Drawing.Size(50, 13);
            this.lblCurrentValue.TabIndex = 4;
            this.lblCurrentValue.Text = "Initialized";
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.lblCurrentValue);
            this.Controls.Add(this.lblFeasible);
            this.Controls.Add(this.lblGeneration);
            this.Controls.Add(this.cbStopped);
            this.Controls.Add(this.btnStop);
            this.Name = "StatusForm";
            this.Text = "Status";
            this.Load += new System.EventHandler(this.StatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.CheckBox cbStopped;
        public System.Windows.Forms.Label lblGeneration;
        public System.Windows.Forms.Label lblFeasible;
        public System.Windows.Forms.Label lblCurrentValue;
    }
}