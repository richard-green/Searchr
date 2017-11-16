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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.ResultsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editWithNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandPromptHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRegex = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkExcludeHidden = new System.Windows.Forms.CheckBox();
            this.chkExcludeSystem = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.txtHidden = new System.Windows.Forms.TextBox();
            this.resultsTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.FileIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbIncludedExtensions = new System.Windows.Forms.ComboBox();
            this.cmbExcludedExtensions = new System.Windows.Forms.ComboBox();
            this.cmbExcludeFolderNames = new System.Windows.Forms.ComboBox();
            this.cmbDirectory = new System.Windows.Forms.ComboBox();
            this.chkExcludeBinaryFiles = new System.Windows.Forms.CheckBox();
            this.ResultsContextMenu.SuspendLayout();
            this.resultsTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTerm.Location = new System.Drawing.Point(153, 13);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(507, 23);
            this.txtSearchTerm.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(669, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkRecursive
            // 
            this.chkRecursive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRecursive.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRecursive.ImageIndex = 3;
            this.chkRecursive.ImageList = this.images;
            this.chkRecursive.Location = new System.Drawing.Point(669, 45);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(157, 25);
            this.chkRecursive.TabIndex = 6;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = true;
            this.chkRecursive.CheckedChanged += new System.EventHandler(this.chk_Changed);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "compass.png");
            this.images.Images.SetKeyName(1, "checked.png");
            this.images.Images.SetKeyName(2, "switch.png");
            this.images.Images.SetKeyName(3, "switch-1.png");
            // 
            // ResultsContextMenu
            // 
            this.ResultsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editWithNotepadToolStripMenuItem,
            this.exploreHereToolStripMenuItem,
            this.commandPromptHereToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clearResultsToolStripMenuItem});
            this.ResultsContextMenu.Name = "ResultsContextMenu";
            this.ResultsContextMenu.Size = new System.Drawing.Size(203, 98);
            // 
            // editWithNotepadToolStripMenuItem
            // 
            this.editWithNotepadToolStripMenuItem.Name = "editWithNotepadToolStripMenuItem";
            this.editWithNotepadToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.editWithNotepadToolStripMenuItem.Text = "Edit with Notepad++";
            this.editWithNotepadToolStripMenuItem.Click += new System.EventHandler(this.editWithNotepadToolStripMenuItem_Click);
            // 
            // exploreHereToolStripMenuItem
            // 
            this.exploreHereToolStripMenuItem.Name = "exploreHereToolStripMenuItem";
            this.exploreHereToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exploreHereToolStripMenuItem.Text = "Explore Here";
            this.exploreHereToolStripMenuItem.Click += new System.EventHandler(this.exploreHereToolStripMenuItem_Click);
            // 
            // commandPromptHereToolStripMenuItem
            // 
            this.commandPromptHereToolStripMenuItem.Name = "commandPromptHereToolStripMenuItem";
            this.commandPromptHereToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.commandPromptHereToolStripMenuItem.Text = "Command Prompt Here";
            this.commandPromptHereToolStripMenuItem.Click += new System.EventHandler(this.commandPromptHereToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // clearResultsToolStripMenuItem
            // 
            this.clearResultsToolStripMenuItem.Name = "clearResultsToolStripMenuItem";
            this.clearResultsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.clearResultsToolStripMenuItem.Text = "Clear Results";
            this.clearResultsToolStripMenuItem.Click += new System.EventHandler(this.clearResultsToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search Term";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Include File Types";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Exclude File Types";
            // 
            // chkRegex
            // 
            this.chkRegex.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRegex.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRegex.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRegex.ImageIndex = 2;
            this.chkRegex.ImageList = this.images;
            this.chkRegex.Location = new System.Drawing.Point(999, 12);
            this.chkRegex.Name = "chkRegex";
            this.chkRegex.Size = new System.Drawing.Size(157, 24);
            this.chkRegex.TabIndex = 4;
            this.chkRegex.Text = "Regular Expression";
            this.chkRegex.UseVisualStyleBackColor = true;
            this.chkRegex.CheckedChanged += new System.EventHandler(this.chk_Changed);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(752, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(74, 25);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkExcludeHidden
            // 
            this.chkExcludeHidden.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkExcludeHidden.Checked = true;
            this.chkExcludeHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeHidden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcludeHidden.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExcludeHidden.ImageIndex = 3;
            this.chkExcludeHidden.ImageList = this.images;
            this.chkExcludeHidden.Location = new System.Drawing.Point(999, 111);
            this.chkExcludeHidden.Name = "chkExcludeHidden";
            this.chkExcludeHidden.Size = new System.Drawing.Size(157, 25);
            this.chkExcludeHidden.TabIndex = 10;
            this.chkExcludeHidden.Text = "Exclude Hidden Files";
            this.chkExcludeHidden.UseVisualStyleBackColor = true;
            this.chkExcludeHidden.CheckedChanged += new System.EventHandler(this.chk_Changed);
            // 
            // chkExcludeSystem
            // 
            this.chkExcludeSystem.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkExcludeSystem.Checked = true;
            this.chkExcludeSystem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeSystem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcludeSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExcludeSystem.ImageIndex = 3;
            this.chkExcludeSystem.ImageList = this.images;
            this.chkExcludeSystem.Location = new System.Drawing.Point(834, 111);
            this.chkExcludeSystem.Name = "chkExcludeSystem";
            this.chkExcludeSystem.Size = new System.Drawing.Size(157, 25);
            this.chkExcludeSystem.TabIndex = 11;
            this.chkExcludeSystem.Text = "Exclude System Files";
            this.chkExcludeSystem.UseVisualStyleBackColor = true;
            this.chkExcludeSystem.CheckedChanged += new System.EventHandler(this.chk_Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Exclude Folder Names";
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMatchCase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMatchCase.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMatchCase.ImageIndex = 2;
            this.chkMatchCase.ImageList = this.images;
            this.chkMatchCase.Location = new System.Drawing.Point(834, 12);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(157, 24);
            this.chkMatchCase.TabIndex = 3;
            this.chkMatchCase.Text = "Case Sensitive";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            this.chkMatchCase.CheckedChanged += new System.EventHandler(this.chk_Changed);
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
            this.resultsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTabs.Controls.Add(this.tabPage1);
            this.resultsTabs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsTabs.ImageList = this.images;
            this.resultsTabs.Location = new System.Drawing.Point(14, 177);
            this.resultsTabs.Name = "resultsTabs";
            this.resultsTabs.Padding = new System.Drawing.Point(10, 6);
            this.resultsTabs.SelectedIndex = 0;
            this.resultsTabs.Size = new System.Drawing.Size(1143, 271);
            this.resultsTabs.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgResults);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage1.Size = new System.Drawing.Size(1135, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Searchr";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToOrderColumns = true;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileIcon,
            this.Lines,
            this.FileName,
            this.Ext,
            this.Directory});
            this.dgResults.ContextMenuStrip = this.ResultsContextMenu;
            this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResults.Location = new System.Drawing.Point(5, 5);
            this.dgResults.Margin = new System.Windows.Forms.Padding(10);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.Size = new System.Drawing.Size(1125, 227);
            this.dgResults.TabIndex = 13;
            // 
            // FileIcon
            // 
            this.FileIcon.HeaderText = "";
            this.FileIcon.Name = "FileIcon";
            this.FileIcon.ReadOnly = true;
            this.FileIcon.Width = 22;
            // 
            // Lines
            // 
            this.Lines.HeaderText = "Lines";
            this.Lines.Name = "Lines";
            this.Lines.ReadOnly = true;
            this.Lines.Width = 40;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 200;
            // 
            // Ext
            // 
            this.Ext.HeaderText = "Ext";
            this.Ext.Name = "Ext";
            this.Ext.ReadOnly = true;
            this.Ext.Width = 50;
            // 
            // Directory
            // 
            this.Directory.HeaderText = "Directory";
            this.Directory.Name = "Directory";
            this.Directory.ReadOnly = true;
            this.Directory.Width = 400;
            // 
            // cmbIncludedExtensions
            // 
            this.cmbIncludedExtensions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIncludedExtensions.FormattingEnabled = true;
            this.cmbIncludedExtensions.Location = new System.Drawing.Point(153, 79);
            this.cmbIncludedExtensions.Name = "cmbIncludedExtensions";
            this.cmbIncludedExtensions.Size = new System.Drawing.Size(507, 23);
            this.cmbIncludedExtensions.TabIndex = 7;
            // 
            // cmbExcludedExtensions
            // 
            this.cmbExcludedExtensions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExcludedExtensions.FormattingEnabled = true;
            this.cmbExcludedExtensions.Location = new System.Drawing.Point(153, 112);
            this.cmbExcludedExtensions.Name = "cmbExcludedExtensions";
            this.cmbExcludedExtensions.Size = new System.Drawing.Size(507, 23);
            this.cmbExcludedExtensions.TabIndex = 8;
            // 
            // cmbExcludeFolderNames
            // 
            this.cmbExcludeFolderNames.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExcludeFolderNames.FormattingEnabled = true;
            this.cmbExcludeFolderNames.Location = new System.Drawing.Point(153, 145);
            this.cmbExcludeFolderNames.Name = "cmbExcludeFolderNames";
            this.cmbExcludeFolderNames.Size = new System.Drawing.Size(507, 23);
            this.cmbExcludeFolderNames.TabIndex = 12;
            // 
            // cmbDirectory
            // 
            this.cmbDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDirectory.FormattingEnabled = true;
            this.cmbDirectory.Location = new System.Drawing.Point(153, 46);
            this.cmbDirectory.Name = "cmbDirectory";
            this.cmbDirectory.Size = new System.Drawing.Size(507, 23);
            this.cmbDirectory.TabIndex = 5;
            // 
            // chkExcludeBinaryFiles
            // 
            this.chkExcludeBinaryFiles.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkExcludeBinaryFiles.Checked = true;
            this.chkExcludeBinaryFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeBinaryFiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcludeBinaryFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExcludeBinaryFiles.ImageIndex = 3;
            this.chkExcludeBinaryFiles.ImageList = this.images;
            this.chkExcludeBinaryFiles.Location = new System.Drawing.Point(669, 111);
            this.chkExcludeBinaryFiles.Name = "chkExcludeBinaryFiles";
            this.chkExcludeBinaryFiles.Size = new System.Drawing.Size(157, 25);
            this.chkExcludeBinaryFiles.TabIndex = 14;
            this.chkExcludeBinaryFiles.Text = "Exclude Binary Files";
            this.chkExcludeBinaryFiles.UseVisualStyleBackColor = true;
            this.chkExcludeBinaryFiles.CheckedChanged += new System.EventHandler(this.chk_Changed);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1169, 461);
            this.Controls.Add(this.chkExcludeBinaryFiles);
            this.Controls.Add(this.cmbExcludeFolderNames);
            this.Controls.Add(this.cmbExcludedExtensions);
            this.Controls.Add(this.cmbDirectory);
            this.Controls.Add(this.cmbIncludedExtensions);
            this.Controls.Add(this.resultsTabs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHidden);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.chkRegex);
            this.Controls.Add(this.chkExcludeSystem);
            this.Controls.Add(this.chkExcludeHidden);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchTerm);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1185, 500);
            this.Name = "frmMain";
            this.Text = "Searchr";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.ResultsContextMenu.ResumeLayout(false);
            this.resultsTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRegex;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkExcludeHidden;
        private System.Windows.Forms.CheckBox chkExcludeSystem;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ContextMenuStrip ResultsContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editWithNotepadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exploreHereToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem commandPromptHereToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem clearResultsToolStripMenuItem;
		private System.Windows.Forms.CheckBox chkMatchCase;
		private System.Windows.Forms.TextBox txtHidden;
		private System.Windows.Forms.TabControl resultsTabs;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGridView dgResults;
		private System.Windows.Forms.DataGridViewImageColumn FileIcon;
		private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Ext;
		private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
        private System.Windows.Forms.ComboBox cmbIncludedExtensions;
        private System.Windows.Forms.ComboBox cmbExcludedExtensions;
        private System.Windows.Forms.ComboBox cmbExcludeFolderNames;
        private System.Windows.Forms.ComboBox cmbDirectory;
        private System.Windows.Forms.CheckBox chkExcludeBinaryFiles;
        private System.Windows.Forms.ImageList images;
    }
}
