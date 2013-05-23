namespace Junction
{
    partial class GanttFormCS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GanttFormCS));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblJobDetail = new System.Windows.Forms.Label();
            this.gntDetail = new Junction.GanttChart();
            this.gntLineOverview = new Junction.GanttChart();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Production Line Overview";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Production Line Detail";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(252, 12);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(35, 13);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "label3";
            // 
            // lblJobDetail
            // 
            this.lblJobDetail.AutoSize = true;
            this.lblJobDetail.Location = new System.Drawing.Point(255, 256);
            this.lblJobDetail.Name = "lblJobDetail";
            this.lblJobDetail.Size = new System.Drawing.Size(35, 13);
            this.lblJobDetail.TabIndex = 5;
            this.lblJobDetail.Text = "label3";
            // 
            // gntDetail
            // 
            this.gntDetail.AllowManualEditBar = true;
            this.gntDetail.BackColor = System.Drawing.Color.White;
            this.gntDetail.DateFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gntDetail.FromDate = new System.DateTime(((long)(0)));
            this.gntDetail.Location = new System.Drawing.Point(12, 275);
            this.gntDetail.Name = "gntDetail";
            this.gntDetail.RowFont = new System.Drawing.Font("Verdana", 8F);
            this.gntDetail.Size = new System.Drawing.Size(1161, 395);
            this.gntDetail.TabIndex = 1;
            this.gntDetail.Text = "ganttChart2";
            this.gntDetail.TimeFont = new System.Drawing.Font("Verdana", 8F);
            this.gntDetail.ToDate = new System.DateTime(((long)(0)));
            this.gntDetail.ToolTipText = ((System.Collections.Generic.List<string>)(resources.GetObject("gntDetail.ToolTipText")));
            this.gntDetail.ToolTipTextTitle = "";
            this.gntDetail.BarChanged += new Junction.GanttChart.BarChangedEventHandler(this.gntDetail_BarChanged);
            // 
            // gntLineOverview
            // 
            this.gntLineOverview.AllowManualEditBar = false;
            this.gntLineOverview.BackColor = System.Drawing.Color.White;
            this.gntLineOverview.DateFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gntLineOverview.FromDate = new System.DateTime(((long)(0)));
            this.gntLineOverview.Location = new System.Drawing.Point(12, 29);
            this.gntLineOverview.Name = "gntLineOverview";
            this.gntLineOverview.RowFont = new System.Drawing.Font("Verdana", 8F);
            this.gntLineOverview.Size = new System.Drawing.Size(1161, 216);
            this.gntLineOverview.TabIndex = 0;
            this.gntLineOverview.Text = "ganttChart1";
            this.gntLineOverview.TimeFont = new System.Drawing.Font("Verdana", 8F);
            this.gntLineOverview.ToDate = new System.DateTime(((long)(0)));
            this.gntLineOverview.ToolTipText = ((System.Collections.Generic.List<string>)(resources.GetObject("gntLineOverview.ToolTipText")));
            this.gntLineOverview.ToolTipTextTitle = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1005, 678);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1098, 678);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GanttFormCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 713);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblJobDetail);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gntDetail);
            this.Controls.Add(this.gntLineOverview);
            this.KeyPreview = true;
            this.Name = "GanttFormCS";
            this.Text = "ProductionWorkbench";
            this.Load += new System.EventHandler(this.GanttFormCS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Junction.GanttChart gntLineOverview;
        private Junction.GanttChart gntDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblJobDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}