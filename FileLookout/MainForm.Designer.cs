namespace FileLookout
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderWatcherObect = new System.IO.FileSystemWatcher();
            this.WatchedFolderLabel = new System.Windows.Forms.Label();
            this.AddFolderButton = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            this.watchedFolderList = new System.Windows.Forms.ListBox();
            this.watchedFolderModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DeleteFolderButton = new System.Windows.Forms.Button();
            this.CheckTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.folderWatcherObect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchedFolderModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Yo!";
            this.notifyIcon.BalloonTipTitle = "FileLookup";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // folderWatcherObect
            // 
            this.folderWatcherObect.EnableRaisingEvents = true;
            this.folderWatcherObect.SynchronizingObject = this;
            this.folderWatcherObect.Created += new System.IO.FileSystemEventHandler(this.folderWatcherObect_Created);
            this.folderWatcherObect.Deleted += new System.IO.FileSystemEventHandler(this.folderWatcherObect_Deleted);
            // 
            // WatchedFolderLabel
            // 
            this.WatchedFolderLabel.AutoSize = true;
            this.WatchedFolderLabel.Location = new System.Drawing.Point(13, 13);
            this.WatchedFolderLabel.Name = "WatchedFolderLabel";
            this.WatchedFolderLabel.Size = new System.Drawing.Size(112, 17);
            this.WatchedFolderLabel.TabIndex = 0;
            this.WatchedFolderLabel.Text = "Watched Folder:";
            // 
            // AddFolderButton
            // 
            this.AddFolderButton.Location = new System.Drawing.Point(12, 143);
            this.AddFolderButton.Name = "AddFolderButton";
            this.AddFolderButton.Size = new System.Drawing.Size(113, 33);
            this.AddFolderButton.TabIndex = 2;
            this.AddFolderButton.Text = "Ajouter";
            this.AddFolderButton.UseVisualStyleBackColor = true;
            this.AddFolderButton.Click += new System.EventHandler(this.AddFolderButton_Click);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(16, 198);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(115, 33);
            this.CheckButton.TabIndex = 3;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // watchedFolderList
            // 
            this.watchedFolderList.DisplayMember = "Path";
            this.watchedFolderList.FormattingEnabled = true;
            this.watchedFolderList.ItemHeight = 16;
            this.watchedFolderList.Location = new System.Drawing.Point(12, 37);
            this.watchedFolderList.Name = "watchedFolderList";
            this.watchedFolderList.Size = new System.Drawing.Size(380, 100);
            this.watchedFolderList.TabIndex = 4;
            this.watchedFolderList.ValueMember = "Path";
            // 
            // watchedFolderModelBindingSource
            // 
            this.watchedFolderModelBindingSource.DataSource = typeof(FileLookout.WatchedFolder);
            // 
            // DeleteFolderButton
            // 
            this.DeleteFolderButton.Location = new System.Drawing.Point(295, 143);
            this.DeleteFolderButton.Name = "DeleteFolderButton";
            this.DeleteFolderButton.Size = new System.Drawing.Size(97, 33);
            this.DeleteFolderButton.TabIndex = 5;
            this.DeleteFolderButton.Text = "Retirer";
            this.DeleteFolderButton.UseVisualStyleBackColor = true;
            this.DeleteFolderButton.Click += new System.EventHandler(this.DeleteFolderButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 253);
            this.Controls.Add(this.DeleteFolderButton);
            this.Controls.Add(this.watchedFolderList);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.AddFolderButton);
            this.Controls.Add(this.WatchedFolderLabel);
            this.Name = "MainForm";
            this.Text = "FileLookout";
            ((System.ComponentModel.ISupportInitialize)(this.folderWatcherObect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchedFolderModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.IO.FileSystemWatcher folderWatcherObect;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Button AddFolderButton;
        private System.Windows.Forms.Label WatchedFolderLabel;
        private System.Windows.Forms.ListBox watchedFolderList;
        private System.Windows.Forms.BindingSource watchedFolderModelBindingSource;
        private System.Windows.Forms.Button DeleteFolderButton;
        private System.Windows.Forms.Timer CheckTimer;
    }
}

