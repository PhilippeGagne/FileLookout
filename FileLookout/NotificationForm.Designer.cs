namespace FileLookout
{
    partial class NotificationForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.FilesDetectedList = new System.Windows.Forms.DataGridView();
            this.FilesDetectedBinding = new System.Windows.Forms.BindingSource(this.components);
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDetectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directoryWatchedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FilesDetectedList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilesDetectedBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(195, 210);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 31);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // FilesDetectedList
            // 
            this.FilesDetectedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesDetectedList.AutoGenerateColumns = false;
            this.FilesDetectedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesDetectedList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathDataGridViewTextBoxColumn,
            this.dateDetectedDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.directoryNameDataGridViewTextBoxColumn,
            this.directoryWatchedDataGridViewTextBoxColumn});
            this.FilesDetectedList.DataSource = this.FilesDetectedBinding;
            this.FilesDetectedList.Location = new System.Drawing.Point(12, 32);
            this.FilesDetectedList.Name = "FilesDetectedList";
            this.FilesDetectedList.RowTemplate.Height = 24;
            this.FilesDetectedList.Size = new System.Drawing.Size(619, 206);
            this.FilesDetectedList.TabIndex = 1;
            // 
            // FilesDetectedBinding
            // 
            this.FilesDetectedBinding.DataSource = typeof(FileLookout.WatchedFile);
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
            // directoryWatchedDataGridViewTextBoxColumn
            // 
            this.directoryWatchedDataGridViewTextBoxColumn.DataPropertyName = "DirectoryWatched";
            this.directoryWatchedDataGridViewTextBoxColumn.HeaderText = "DirectoryWatched";
            this.directoryWatchedDataGridViewTextBoxColumn.Name = "directoryWatchedDataGridViewTextBoxColumn";
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 309);
            this.Controls.Add(this.FilesDetectedList);
            this.Controls.Add(this.OkButton);
            this.Name = "NotificationForm";
            this.Text = "NotificationForm";
            ((System.ComponentModel.ISupportInitialize)(this.FilesDetectedList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilesDetectedBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.DataGridView FilesDetectedList;
        private System.Windows.Forms.BindingSource FilesDetectedBinding;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDetectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directoryWatchedDataGridViewTextBoxColumn;
    }
}