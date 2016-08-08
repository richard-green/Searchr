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
            this.ResultsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editWithNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandPromptHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcludeBinaryFiles = new System.Windows.Forms.Button();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.FileIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cmbIncludedExtensions = new System.Windows.Forms.ComboBox();
            this.cmbExcludedExtensions = new System.Windows.Forms.ComboBox();
            this.cmbExcludeFolderNames = new System.Windows.Forms.ComboBox();
            this.cmbDirectory = new System.Windows.Forms.ComboBox();
            this.ResultsContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(136, 11);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(267, 20);
            this.txtSearchTerm.TabIndex = 0;
            this.txtSearchTerm.Text = "using ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(409, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(410, 41);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(74, 17);
            this.chkRecursive.TabIndex = 8;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = true;
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
            // btnExcludeBinaryFiles
            // 
            this.btnExcludeBinaryFiles.Location = new System.Drawing.Point(409, 93);
            this.btnExcludeBinaryFiles.Name = "btnExcludeBinaryFiles";
            this.btnExcludeBinaryFiles.Size = new System.Drawing.Size(126, 23);
            this.btnExcludeBinaryFiles.TabIndex = 9;
            this.btnExcludeBinaryFiles.Text = "Exclude Binary Files";
            this.btnExcludeBinaryFiles.UseVisualStyleBackColor = true;
            this.btnExcludeBinaryFiles.Click += new System.EventHandler(this.btnExcludeBinaryFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search Term";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Include File Types";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Exclude File Types";
            // 
            // chkRegex
            // 
            this.chkRegex.AutoSize = true;
            this.chkRegex.Location = new System.Drawing.Point(646, 13);
            this.chkRegex.Name = "chkRegex";
            this.chkRegex.Size = new System.Drawing.Size(117, 17);
            this.chkRegex.TabIndex = 7;
            this.chkRegex.Text = "Regular Expression";
            this.chkRegex.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(475, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkExcludeHidden
            // 
            this.chkExcludeHidden.AutoSize = true;
            this.chkExcludeHidden.Checked = true;
            this.chkExcludeHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeHidden.Location = new System.Drawing.Point(544, 97);
            this.chkExcludeHidden.Name = "chkExcludeHidden";
            this.chkExcludeHidden.Size = new System.Drawing.Size(101, 17);
            this.chkExcludeHidden.TabIndex = 10;
            this.chkExcludeHidden.Text = "Exclude Hidden";
            this.chkExcludeHidden.UseVisualStyleBackColor = true;
            // 
            // chkExcludeSystem
            // 
            this.chkExcludeSystem.AutoSize = true;
            this.chkExcludeSystem.Checked = true;
            this.chkExcludeSystem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeSystem.Location = new System.Drawing.Point(646, 97);
            this.chkExcludeSystem.Name = "chkExcludeSystem";
            this.chkExcludeSystem.Size = new System.Drawing.Size(101, 17);
            this.chkExcludeSystem.TabIndex = 11;
            this.chkExcludeSystem.Text = "Exclude System";
            this.chkExcludeSystem.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Exclude Folder Names";
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(544, 13);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(96, 17);
            this.chkMatchCase.TabIndex = 7;
            this.chkMatchCase.Text = "Case Sensitive";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // txtHidden
            // 
            this.txtHidden.Location = new System.Drawing.Point(-300, 0);
            this.txtHidden.Name = "txtHidden";
            this.txtHidden.Size = new System.Drawing.Size(250, 20);
            this.txtHidden.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 149);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1312, 557);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgResults);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1304, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToOrderColumns = true;
            this.dgResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileIcon,
            this.Lines,
            this.FileName,
            this.Ext,
            this.Directory});
            this.dgResults.ContextMenuStrip = this.ResultsContextMenu;
            this.dgResults.Location = new System.Drawing.Point(3, 3);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.Size = new System.Drawing.Size(1298, 525);
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 709);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1336, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cmbIncludedExtensions
            // 
            this.cmbIncludedExtensions.FormattingEnabled = true;
            this.cmbIncludedExtensions.Location = new System.Drawing.Point(136, 66);
            this.cmbIncludedExtensions.Name = "cmbIncludedExtensions";
            this.cmbIncludedExtensions.Size = new System.Drawing.Size(267, 21);
            this.cmbIncludedExtensions.TabIndex = 15;
            // 
            // cmbExcludedExtensions
            // 
            this.cmbExcludedExtensions.FormattingEnabled = true;
            this.cmbExcludedExtensions.Location = new System.Drawing.Point(136, 94);
            this.cmbExcludedExtensions.Name = "cmbExcludedExtensions";
            this.cmbExcludedExtensions.Size = new System.Drawing.Size(267, 21);
            this.cmbExcludedExtensions.TabIndex = 15;
            // 
            // cmbExcludeFolderNames
            // 
            this.cmbExcludeFolderNames.FormattingEnabled = true;
            this.cmbExcludeFolderNames.Location = new System.Drawing.Point(136, 123);
            this.cmbExcludeFolderNames.Name = "cmbExcludeFolderNames";
            this.cmbExcludeFolderNames.Size = new System.Drawing.Size(267, 21);
            this.cmbExcludeFolderNames.TabIndex = 15;
            // 
            // cmbDirectory
            // 
            this.cmbDirectory.FormattingEnabled = true;
            this.cmbDirectory.Location = new System.Drawing.Point(136, 38);
            this.cmbDirectory.Name = "cmbDirectory";
            this.cmbDirectory.Size = new System.Drawing.Size(267, 21);
            this.cmbDirectory.TabIndex = 15;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 731);
            this.Controls.Add(this.cmbExcludeFolderNames);
            this.Controls.Add(this.cmbExcludedExtensions);
            this.Controls.Add(this.cmbDirectory);
            this.Controls.Add(this.cmbIncludedExtensions);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
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
            this.Controls.Add(this.btnExcludeBinaryFiles);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchTerm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(875, 385);
            this.Name = "frmMain";
            this.Text = "Searchr";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.ResultsContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkRecursive;
		private System.Windows.Forms.Button btnExcludeBinaryFiles;
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
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGridView dgResults;
		private System.Windows.Forms.DataGridViewImageColumn FileIcon;
		private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Ext;
		private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cmbIncludedExtensions;
        private System.Windows.Forms.ComboBox cmbExcludedExtensions;
        private System.Windows.Forms.ComboBox cmbExcludeFolderNames;
        private System.Windows.Forms.ComboBox cmbDirectory;
    }
}