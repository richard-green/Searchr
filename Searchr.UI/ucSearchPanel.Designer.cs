namespace Searchr.UI
{
    partial class ucSearchPanel
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkExcludeBinaryFiles = new System.Windows.Forms.CheckBox();
            this.cmbExcludeFolderNames = new System.Windows.Forms.ComboBox();
            this.cmbExcludedExtensions = new System.Windows.Forms.ComboBox();
            this.cmbDirectory = new System.Windows.Forms.ComboBox();
            this.cmbIncludedExtensions = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.chkRegex = new System.Windows.Forms.CheckBox();
            this.chkExcludeSystem = new System.Windows.Forms.CheckBox();
            this.chkExcludeHidden = new System.Windows.Forms.CheckBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.ResultsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editWithNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandPromptHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.ResultsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.chkExcludeBinaryFiles);
            this.panel1.Controls.Add(this.cmbExcludeFolderNames);
            this.panel1.Controls.Add(this.cmbExcludedExtensions);
            this.panel1.Controls.Add(this.cmbDirectory);
            this.panel1.Controls.Add(this.cmbIncludedExtensions);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkMatchCase);
            this.panel1.Controls.Add(this.chkRegex);
            this.panel1.Controls.Add(this.chkExcludeSystem);
            this.panel1.Controls.Add(this.chkExcludeHidden);
            this.panel1.Controls.Add(this.chkRecursive);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearchTerm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1339, 182);
            this.panel1.TabIndex = 33;
            // 
            // chkExcludeBinaryFiles
            // 
            this.chkExcludeBinaryFiles.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkExcludeBinaryFiles.Checked = true;
            this.chkExcludeBinaryFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeBinaryFiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcludeBinaryFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExcludeBinaryFiles.ImageIndex = 3;
            this.chkExcludeBinaryFiles.Location = new System.Drawing.Point(658, 110);
            this.chkExcludeBinaryFiles.Name = "chkExcludeBinaryFiles";
            this.chkExcludeBinaryFiles.Size = new System.Drawing.Size(157, 25);
            this.chkExcludeBinaryFiles.TabIndex = 50;
            this.chkExcludeBinaryFiles.Text = "Exclude Binary Files";
            this.chkExcludeBinaryFiles.UseVisualStyleBackColor = true;
            this.chkExcludeBinaryFiles.CheckedChanged += new System.EventHandler(this.chk_Changed);
            // 
            // cmbExcludeFolderNames
            // 
            this.cmbExcludeFolderNames.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExcludeFolderNames.FormattingEnabled = true;
            this.cmbExcludeFolderNames.Location = new System.Drawing.Point(142, 144);
            this.cmbExcludeFolderNames.Name = "cmbExcludeFolderNames";
            this.cmbExcludeFolderNames.Size = new System.Drawing.Size(507, 23);
            this.cmbExcludeFolderNames.TabIndex = 49;
            // 
            // cmbExcludedExtensions
            // 
            this.cmbExcludedExtensions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExcludedExtensions.FormattingEnabled = true;
            this.cmbExcludedExtensions.Location = new System.Drawing.Point(142, 111);
            this.cmbExcludedExtensions.Name = "cmbExcludedExtensions";
            this.cmbExcludedExtensions.Size = new System.Drawing.Size(507, 23);
            this.cmbExcludedExtensions.TabIndex = 46;
            // 
            // cmbDirectory
            // 
            this.cmbDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDirectory.FormattingEnabled = true;
            this.cmbDirectory.Location = new System.Drawing.Point(142, 45);
            this.cmbDirectory.Name = "cmbDirectory";
            this.cmbDirectory.Size = new System.Drawing.Size(507, 23);
            this.cmbDirectory.TabIndex = 42;
            // 
            // cmbIncludedExtensions
            // 
            this.cmbIncludedExtensions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIncludedExtensions.FormattingEnabled = true;
            this.cmbIncludedExtensions.Location = new System.Drawing.Point(142, 78);
            this.cmbIncludedExtensions.Name = "cmbIncludedExtensions";
            this.cmbIncludedExtensions.Size = new System.Drawing.Size(507, 23);
            this.cmbIncludedExtensions.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 43;
            this.label5.Text = "Exclude Folder Names";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "Exclude File Types";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "Include File Types";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 40;
            this.label2.Text = "Directory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Search Term";
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMatchCase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMatchCase.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMatchCase.ImageIndex = 2;
            this.chkMatchCase.Location = new System.Drawing.Point(823, 11);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(157, 24);
            this.chkMatchCase.TabIndex = 36;
            this.chkMatchCase.Text = "Case Sensitive";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            this.chkMatchCase.Click += new System.EventHandler(this.chk_Changed);
            // 
            // chkRegex
            // 
            this.chkRegex.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRegex.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRegex.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRegex.ImageIndex = 2;
            this.chkRegex.Location = new System.Drawing.Point(988, 11);
            this.chkRegex.Name = "chkRegex";
            this.chkRegex.Size = new System.Drawing.Size(157, 24);
            this.chkRegex.TabIndex = 37;
            this.chkRegex.Text = "Regular Expression";
            this.chkRegex.UseVisualStyleBackColor = true;
            this.chkRegex.Click += new System.EventHandler(this.chk_Changed);
            // 
            // chkExcludeSystem
            // 
            this.chkExcludeSystem.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkExcludeSystem.Checked = true;
            this.chkExcludeSystem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeSystem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcludeSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExcludeSystem.ImageIndex = 3;
            this.chkExcludeSystem.Location = new System.Drawing.Point(823, 110);
            this.chkExcludeSystem.Name = "chkExcludeSystem";
            this.chkExcludeSystem.Size = new System.Drawing.Size(157, 25);
            this.chkExcludeSystem.TabIndex = 48;
            this.chkExcludeSystem.Text = "Exclude System Files";
            this.chkExcludeSystem.UseVisualStyleBackColor = true;
            this.chkExcludeSystem.CheckedChanged += new System.EventHandler(this.chk_Changed);
            // 
            // chkExcludeHidden
            // 
            this.chkExcludeHidden.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkExcludeHidden.Checked = true;
            this.chkExcludeHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeHidden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcludeHidden.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExcludeHidden.ImageIndex = 3;
            this.chkExcludeHidden.Location = new System.Drawing.Point(988, 110);
            this.chkExcludeHidden.Name = "chkExcludeHidden";
            this.chkExcludeHidden.Size = new System.Drawing.Size(157, 25);
            this.chkExcludeHidden.TabIndex = 47;
            this.chkExcludeHidden.Text = "Exclude Hidden Files";
            this.chkExcludeHidden.UseVisualStyleBackColor = true;
            this.chkExcludeHidden.CheckedChanged += new System.EventHandler(this.chk_Changed);
            // 
            // chkRecursive
            // 
            this.chkRecursive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRecursive.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRecursive.ImageIndex = 3;
            this.chkRecursive.Location = new System.Drawing.Point(658, 44);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(157, 25);
            this.chkRecursive.TabIndex = 44;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = true;
            this.chkRecursive.Click += new System.EventHandler(this.chk_Changed);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(741, 11);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(74, 25);
            this.btnStop.TabIndex = 35;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(658, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTerm.Location = new System.Drawing.Point(142, 12);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(507, 23);
            this.txtSearchTerm.TabIndex = 33;
            this.txtSearchTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchTerm_KeyPress);
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToOrderColumns = true;
            this.dgResults.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileIcon,
            this.Lines,
            this.FileName,
            this.Ext,
            this.Directory});
            this.dgResults.ContextMenuStrip = this.ResultsContextMenu;
            this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResults.Location = new System.Drawing.Point(0, 182);
            this.dgResults.Margin = new System.Windows.Forms.Padding(10);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.Size = new System.Drawing.Size(1339, 464);
            this.dgResults.TabIndex = 34;
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
            this.Directory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Directory.HeaderText = "Directory";
            this.Directory.Name = "Directory";
            this.Directory.ReadOnly = true;
            // 
            // ucSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgResults);
            this.Controls.Add(this.panel1);
            this.Name = "ucSearchPanel";
            this.Size = new System.Drawing.Size(1339, 646);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.ResultsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkExcludeBinaryFiles;
        private System.Windows.Forms.ComboBox cmbExcludeFolderNames;
        private System.Windows.Forms.ComboBox cmbExcludedExtensions;
        private System.Windows.Forms.ComboBox cmbDirectory;
        private System.Windows.Forms.ComboBox cmbIncludedExtensions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.CheckBox chkRegex;
        private System.Windows.Forms.CheckBox chkExcludeSystem;
        private System.Windows.Forms.CheckBox chkExcludeHidden;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.ContextMenuStrip ResultsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editWithNotepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandPromptHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearResultsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn FileIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ext;
        private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
    }
}
