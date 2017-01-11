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
            this.WatchedFolderText = new System.Windows.Forms.TextBox();
            this.WatchedFolderButton = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.folderWatcherObect)).BeginInit();
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
            // WatchedFolderText
            // 
            this.WatchedFolderText.Location = new System.Drawing.Point(16, 42);
            this.WatchedFolderText.Name = "WatchedFolderText";
            this.WatchedFolderText.Size = new System.Drawing.Size(302, 22);
            this.WatchedFolderText.TabIndex = 1;
            // 
            // WatchedFolderButton
            // 
            this.WatchedFolderButton.Location = new System.Drawing.Point(324, 37);
            this.WatchedFolderButton.Name = "WatchedFolderButton";
            this.WatchedFolderButton.Size = new System.Drawing.Size(68, 33);
            this.WatchedFolderButton.TabIndex = 2;
            this.WatchedFolderButton.Text = "...";
            this.WatchedFolderButton.UseVisualStyleBackColor = true;
            this.WatchedFolderButton.Click += new System.EventHandler(this.WatchedFolderButton_Click);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(16, 143);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(115, 33);
            this.CheckButton.TabIndex = 3;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 253);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.WatchedFolderButton);
            this.Controls.Add(this.WatchedFolderText);
            this.Controls.Add(this.WatchedFolderLabel);
            this.Name = "MainForm";
            this.Text = "FileLookout";
            ((System.ComponentModel.ISupportInitialize)(this.folderWatcherObect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.IO.FileSystemWatcher folderWatcherObect;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Button WatchedFolderButton;
        private System.Windows.Forms.TextBox WatchedFolderText;
        private System.Windows.Forms.Label WatchedFolderLabel;
    }
}

