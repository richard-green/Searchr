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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSearchPanel));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbExcludeFolderNames = new System.Windows.Forms.ComboBox();
            this.chkSearchFilePath = new System.Windows.Forms.CheckBox();
            this.chkIncludeHidden = new System.Windows.Forms.CheckBox();
            this.chkIncludeSystem = new System.Windows.Forms.CheckBox();
            this.cmbExcludeFilePatterns = new System.Windows.Forms.ComboBox();
            this.chkIncludeBinaryFiles = new System.Windows.Forms.CheckBox();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRegex = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.cmbIncludeFilePatterns = new System.Windows.Forms.ComboBox();
            this.chkSearchFileName = new System.Windows.Forms.CheckBox();
            this.chkSearchFileContents = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ucDirectory1 = new Searchr.UI.ucDirectory();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.ResultsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editWithNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandPromptHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.FileIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ResultsContextMenu.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.White;
            this.pnlControls.Controls.Add(this.splitter1);
            this.pnlControls.Controls.Add(this.tableLayoutPanel1);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1339, 162);
            this.pnlControls.TabIndex = 33;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 162);
            this.splitter1.TabIndex = 45;
            this.splitter1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbExcludeFolderNames, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkSearchFilePath, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkIncludeHidden, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkIncludeSystem, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbExcludeFilePatterns, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkIncludeBinaryFiles, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchTerm, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkRegex, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkMatchCase, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbIncludeFilePatterns, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkSearchFileName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkSearchFileContents, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkRecursive, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnFilter, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.ucDirectory1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1339, 162);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.label5.Size = new System.Drawing.Size(127, 19);
            this.label5.TabIndex = 43;
            this.label5.Text = "Exclude Folder Names";
            // 
            // cmbExcludeFolderNames
            // 
            this.cmbExcludeFolderNames.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbExcludeFolderNames.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExcludeFolderNames.FormattingEnabled = true;
            this.cmbExcludeFolderNames.Location = new System.Drawing.Point(130, 127);
            this.cmbExcludeFolderNames.Margin = new System.Windows.Forms.Padding(0, 1, 9, 0);
            this.cmbExcludeFolderNames.Name = "cmbExcludeFolderNames";
            this.cmbExcludeFolderNames.Size = new System.Drawing.Size(810, 23);
            this.cmbExcludeFolderNames.TabIndex = 5;
            // 
            // chkSearchFilePath
            // 
            this.chkSearchFilePath.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSearchFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.chkSearchFilePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchFilePath.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSearchFilePath.ImageIndex = 2;
            this.chkSearchFilePath.Location = new System.Drawing.Point(1209, 6);
            this.chkSearchFilePath.Margin = new System.Windows.Forms.Padding(0);
            this.chkSearchFilePath.Name = "chkSearchFilePath";
            this.chkSearchFilePath.Size = new System.Drawing.Size(122, 24);
            this.chkSearchFilePath.TabIndex = 8;
            this.chkSearchFilePath.Text = "File Path";
            this.chkSearchFilePath.UseVisualStyleBackColor = false;
            // 
            // chkIncludeHidden
            // 
            this.chkIncludeHidden.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIncludeHidden.BackColor = System.Drawing.SystemColors.Control;
            this.chkIncludeHidden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeHidden.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludeHidden.ImageIndex = 3;
            this.chkIncludeHidden.Location = new System.Drawing.Point(1209, 66);
            this.chkIncludeHidden.Margin = new System.Windows.Forms.Padding(0);
            this.chkIncludeHidden.Name = "chkIncludeHidden";
            this.chkIncludeHidden.Size = new System.Drawing.Size(122, 24);
            this.chkIncludeHidden.TabIndex = 14;
            this.chkIncludeHidden.Text = "Hidden Files";
            this.chkIncludeHidden.UseVisualStyleBackColor = false;
            // 
            // chkIncludeSystem
            // 
            this.chkIncludeSystem.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIncludeSystem.BackColor = System.Drawing.SystemColors.Control;
            this.chkIncludeSystem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludeSystem.ImageIndex = 3;
            this.chkIncludeSystem.Location = new System.Drawing.Point(1079, 66);
            this.chkIncludeSystem.Margin = new System.Windows.Forms.Padding(0);
            this.chkIncludeSystem.Name = "chkIncludeSystem";
            this.chkIncludeSystem.Size = new System.Drawing.Size(122, 24);
            this.chkIncludeSystem.TabIndex = 13;
            this.chkIncludeSystem.Text = "System Files";
            this.chkIncludeSystem.UseVisualStyleBackColor = false;
            // 
            // cmbExcludeFilePatterns
            // 
            this.cmbExcludeFilePatterns.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbExcludeFilePatterns.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExcludeFilePatterns.FormattingEnabled = true;
            this.cmbExcludeFilePatterns.Location = new System.Drawing.Point(130, 97);
            this.cmbExcludeFilePatterns.Margin = new System.Windows.Forms.Padding(0, 1, 9, 0);
            this.cmbExcludeFilePatterns.Name = "cmbExcludeFilePatterns";
            this.cmbExcludeFilePatterns.Size = new System.Drawing.Size(810, 23);
            this.cmbExcludeFilePatterns.TabIndex = 4;
            // 
            // chkIncludeBinaryFiles
            // 
            this.chkIncludeBinaryFiles.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIncludeBinaryFiles.BackColor = System.Drawing.SystemColors.Control;
            this.chkIncludeBinaryFiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeBinaryFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludeBinaryFiles.ImageIndex = 3;
            this.chkIncludeBinaryFiles.Location = new System.Drawing.Point(949, 66);
            this.chkIncludeBinaryFiles.Margin = new System.Windows.Forms.Padding(0);
            this.chkIncludeBinaryFiles.Name = "chkIncludeBinaryFiles";
            this.chkIncludeBinaryFiles.Size = new System.Drawing.Size(122, 24);
            this.chkIncludeBinaryFiles.TabIndex = 12;
            this.chkIncludeBinaryFiles.Text = "Binary Files";
            this.chkIncludeBinaryFiles.UseVisualStyleBackColor = false;
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchTerm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTerm.Location = new System.Drawing.Point(130, 7);
            this.txtSearchTerm.Margin = new System.Windows.Forms.Padding(0, 1, 9, 0);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(810, 23);
            this.txtSearchTerm.TabIndex = 0;
            this.txtSearchTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchTerm_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.label4.Size = new System.Drawing.Size(118, 19);
            this.label4.TabIndex = 41;
            this.label4.Text = "Exclude File Patterns";
            // 
            // chkRegex
            // 
            this.chkRegex.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRegex.BackColor = System.Drawing.SystemColors.Control;
            this.chkRegex.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRegex.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRegex.ImageIndex = 2;
            this.chkRegex.Location = new System.Drawing.Point(1209, 36);
            this.chkRegex.Margin = new System.Windows.Forms.Padding(0);
            this.chkRegex.Name = "chkRegex";
            this.chkRegex.Size = new System.Drawing.Size(122, 24);
            this.chkRegex.TabIndex = 11;
            this.chkRegex.Text = "Regular Expression";
            this.chkRegex.UseVisualStyleBackColor = false;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMatchCase.BackColor = System.Drawing.SystemColors.Control;
            this.chkMatchCase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMatchCase.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMatchCase.ImageIndex = 2;
            this.chkMatchCase.Location = new System.Drawing.Point(1079, 36);
            this.chkMatchCase.Margin = new System.Windows.Forms.Padding(0);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(122, 24);
            this.chkMatchCase.TabIndex = 10;
            this.chkMatchCase.Text = "Case Sensitive";
            this.chkMatchCase.UseVisualStyleBackColor = false;
            // 
            // cmbIncludeFilePatterns
            // 
            this.cmbIncludeFilePatterns.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIncludeFilePatterns.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIncludeFilePatterns.FormattingEnabled = true;
            this.cmbIncludeFilePatterns.Location = new System.Drawing.Point(130, 67);
            this.cmbIncludeFilePatterns.Margin = new System.Windows.Forms.Padding(0, 1, 9, 0);
            this.cmbIncludeFilePatterns.Name = "cmbIncludeFilePatterns";
            this.cmbIncludeFilePatterns.Size = new System.Drawing.Size(810, 23);
            this.cmbIncludeFilePatterns.TabIndex = 3;
            // 
            // chkSearchFileName
            // 
            this.chkSearchFileName.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSearchFileName.BackColor = System.Drawing.SystemColors.Control;
            this.chkSearchFileName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchFileName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSearchFileName.ImageIndex = 2;
            this.chkSearchFileName.Location = new System.Drawing.Point(1079, 6);
            this.chkSearchFileName.Margin = new System.Windows.Forms.Padding(0);
            this.chkSearchFileName.Name = "chkSearchFileName";
            this.chkSearchFileName.Size = new System.Drawing.Size(122, 24);
            this.chkSearchFileName.TabIndex = 7;
            this.chkSearchFileName.Text = "File Name";
            this.chkSearchFileName.UseVisualStyleBackColor = false;
            // 
            // chkSearchFileContents
            // 
            this.chkSearchFileContents.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSearchFileContents.BackColor = System.Drawing.SystemColors.Control;
            this.chkSearchFileContents.Checked = true;
            this.chkSearchFileContents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSearchFileContents.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchFileContents.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSearchFileContents.ImageIndex = 2;
            this.chkSearchFileContents.Location = new System.Drawing.Point(949, 6);
            this.chkSearchFileContents.Margin = new System.Windows.Forms.Padding(0);
            this.chkSearchFileContents.Name = "chkSearchFileContents";
            this.chkSearchFileContents.Size = new System.Drawing.Size(122, 24);
            this.chkSearchFileContents.TabIndex = 6;
            this.chkSearchFileContents.Text = "File Contents";
            this.chkSearchFileContents.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 39;
            this.label3.Text = "Include File Patterns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "Search Term";
            // 
            // chkRecursive
            // 
            this.chkRecursive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRecursive.BackColor = System.Drawing.SystemColors.Control;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRecursive.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRecursive.ImageIndex = 3;
            this.chkRecursive.Location = new System.Drawing.Point(949, 36);
            this.chkRecursive.Margin = new System.Windows.Forms.Padding(0);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(122, 24);
            this.chkRecursive.TabIndex = 9;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "Directory";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Salmon;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(949, 126);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(122, 24);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(1079, 126);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(0);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(122, 24);
            this.btnFilter.TabIndex = 16;
            this.btnFilter.Text = "Filter";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1209, 126);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 24);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ucDirectory1
            // 
            this.ucDirectory1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucDirectory1.Location = new System.Drawing.Point(130, 36);
            this.ucDirectory1.Margin = new System.Windows.Forms.Padding(0);
            this.ucDirectory1.Name = "ucDirectory1";
            this.ucDirectory1.Size = new System.Drawing.Size(819, 24);
            this.ucDirectory1.TabIndex = 2;
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "icons8-play-16.png");
            this.images.Images.SetKeyName(1, "icons8-stop-16.png");
            this.images.Images.SetKeyName(2, "icons8-play-48.png");
            this.images.Images.SetKeyName(3, "icons8-stop-48.png");
            this.images.Images.SetKeyName(4, "icons8-next-48.png");
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
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.statusStrip1);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 624);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1339, 22);
            this.pnlStatus.TabIndex = 34;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1339, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.statusText.Size = new System.Drawing.Size(3, 17);
            // 
            // pnlResults
            // 
            this.pnlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResults.Location = new System.Drawing.Point(0, 162);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(1339, 462);
            this.pnlResults.TabIndex = 35;
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
            this.Directory,
            this.FileSize});
            this.dgResults.ContextMenuStrip = this.ResultsContextMenu;
            this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResults.Location = new System.Drawing.Point(0, 162);
            this.dgResults.Margin = new System.Windows.Forms.Padding(10);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.Size = new System.Drawing.Size(1339, 462);
            this.dgResults.TabIndex = 18;
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
            this.FileName.HeaderText = "File name";
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
            this.Directory.Width = 884;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "File size";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // ucSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgResults);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlControls);
            this.Name = "ucSearchPanel";
            this.Size = new System.Drawing.Size(1339, 646);
            this.pnlControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResultsContextMenu.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.ContextMenuStrip ResultsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editWithNotepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandPromptHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearResultsToolStripMenuItem;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.CheckBox chkSearchFilePath;
        private System.Windows.Forms.CheckBox chkSearchFileName;
        private System.Windows.Forms.CheckBox chkIncludeBinaryFiles;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.CheckBox chkRegex;
        private System.Windows.Forms.CheckBox chkIncludeSystem;
        private System.Windows.Forms.CheckBox chkIncludeHidden;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cmbExcludeFolderNames;
        private System.Windows.Forms.ComboBox cmbExcludeFilePatterns;
        private System.Windows.Forms.ComboBox cmbIncludeFilePatterns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.CheckBox chkSearchFileContents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private ucDirectory ucDirectory1;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.DataGridViewImageColumn FileIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ext;
        private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
    }
}
