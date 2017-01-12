namespace FileLookout
{
    partial class InfoForm
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
            this.FolderInfoList = new System.Windows.Forms.ListBox();
            this.WatchedFoldersLabel = new System.Windows.Forms.Label();
            this.WarchedFilesLabel = new System.Windows.Forms.Label();
            this.FileEventsDataView = new System.Windows.Forms.DataGridView();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDetectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.watchedFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FileEventsDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchedFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FolderInfoList
            // 
            this.FolderInfoList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderInfoList.FormattingEnabled = true;
            this.FolderInfoList.ItemHeight = 16;
            this.FolderInfoList.Location = new System.Drawing.Point(12, 36);
            this.FolderInfoList.Name = "FolderInfoList";
            this.FolderInfoList.Size = new System.Drawing.Size(1031, 196);
            this.FolderInfoList.TabIndex = 0;
            this.FolderInfoList.DoubleClick += new System.EventHandler(this.FolderInfoList_DoubleClick);
            // 
            // WatchedFoldersLabel
            // 
            this.WatchedFoldersLabel.AutoSize = true;
            this.WatchedFoldersLabel.Location = new System.Drawing.Point(13, 13);
            this.WatchedFoldersLabel.Name = "WatchedFoldersLabel";
            this.WatchedFoldersLabel.Size = new System.Drawing.Size(145, 17);
            this.WatchedFoldersLabel.TabIndex = 1;
            this.WatchedFoldersLabel.Text = "Répertoires surveillés";
            // 
            // WarchedFilesLabel
            // 
            this.WarchedFilesLabel.AutoSize = true;
            this.WarchedFilesLabel.Location = new System.Drawing.Point(13, 248);
            this.WarchedFilesLabel.Name = "WarchedFilesLabel";
            this.WarchedFilesLabel.Size = new System.Drawing.Size(86, 17);
            this.WarchedFilesLabel.TabIndex = 3;
            this.WarchedFilesLabel.Text = "Événements";
            // 
            // FileEventsDataView
            // 
            this.FileEventsDataView.AllowUserToAddRows = false;
            this.FileEventsDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileEventsDataView.AutoGenerateColumns = false;
            this.FileEventsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileEventsDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathDataGridViewTextBoxColumn,
            this.dateDetectedDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.directoryNameDataGridViewTextBoxColumn});
            this.FileEventsDataView.DataSource = this.watchedFileBindingSource;
            this.FileEventsDataView.Location = new System.Drawing.Point(16, 278);
            this.FileEventsDataView.Name = "FileEventsDataView";
            this.FileEventsDataView.RowTemplate.Height = 24;
            this.FileEventsDataView.Size = new System.Drawing.Size(1027, 224);
            this.FileEventsDataView.TabIndex = 4;
            this.FileEventsDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileEventsDataView_CellContentClick);
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // dateDetectedDataGridViewTextBoxColumn
            // 
            this.dateDetectedDataGridViewTextBoxColumn.DataPropertyName = "DateDetected";
            this.dateDetectedDataGridViewTextBoxColumn.HeaderText = "DateDetected";
            this.dateDetectedDataGridViewTextBoxColumn.Name = "dateDetectedDataGridViewTextBoxColumn";
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // directoryNameDataGridViewTextBoxColumn
            // 
            this.directoryNameDataGridViewTextBoxColumn.DataPropertyName = "DirectoryName";
            this.directoryNameDataGridViewTextBoxColumn.HeaderText = "DirectoryName";
            this.directoryNameDataGridViewTextBoxColumn.Name = "directoryNameDataGridViewTextBoxColumn";
            this.directoryNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // watchedFileBindingSource
            // 
            this.watchedFileBindingSource.DataSource = typeof(FileLookout.WatchedFile);
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 568);
            this.Controls.Add(this.FileEventsDataView);
            this.Controls.Add(this.WarchedFilesLabel);
            this.Controls.Add(this.WatchedFoldersLabel);
            this.Controls.Add(this.FolderInfoList);
            this.Name = "InfoForm";
            this.Text = "Informations";
            ((System.ComponentModel.ISupportInitialize)(this.FileEventsDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchedFileBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FolderInfoList;
        private System.Windows.Forms.Label WatchedFoldersLabel;
        private System.Windows.Forms.Label WarchedFilesLabel;
        private System.Windows.Forms.DataGridView FileEventsDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDetectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource watchedFileBindingSource;
    }
}