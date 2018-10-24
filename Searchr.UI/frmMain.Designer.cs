namespace Searchr.UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtHidden = new System.Windows.Forms.TextBox();
            this.resultsTabs = new System.Windows.Forms.TabControl();
            this.tabNew = new System.Windows.Forms.TabPage();
            this.resultsTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHidden
            // 
            this.txtHidden.Location = new System.Drawing.Point(-350, 0);
            this.txtHidden.Name = "txtHidden";
            this.txtHidden.Size = new System.Drawing.Size(291, 23);
            this.txtHidden.TabIndex = 4;
            // 
            // resultsTabs
            // 
            this.resultsTabs.Controls.Add(this.tabNew);
            this.resultsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTabs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsTabs.Location = new System.Drawing.Point(5, 5);
            this.resultsTabs.Margin = new System.Windows.Forms.Padding(0);
            this.resultsTabs.Name = "resultsTabs";
            this.resultsTabs.Padding = new System.Drawing.Point(10, 6);
            this.resultsTabs.SelectedIndex = 0;
            this.resultsTabs.Size = new System.Drawing.Size(1369, 647);
            this.resultsTabs.TabIndex = 13;
            this.resultsTabs.SelectedIndexChanged += new System.EventHandler(this.resultsTabs_SelectedIndexChanged);
            this.resultsTabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resultsTabs_MouseClick);
            // 
            // tabNew
            // 
            this.tabNew.BackColor = System.Drawing.Color.Transparent;
            this.tabNew.Location = new System.Drawing.Point(4, 30);
            this.tabNew.Name = "tabNew";
            this.tabNew.Size = new System.Drawing.Size(1361, 613);
            this.tabNew.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1379, 657);
            this.Controls.Add(this.resultsTabs);
            this.Controls.Add(this.txtHidden);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Searchr";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.resultsTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtHidden;
        private System.Windows.Forms.TabControl resultsTabs;
        private System.Windows.Forms.TabPage tabNew;
    }
}
