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
            this.SystemTrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowInformationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowConfigurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitApplicationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderWatcherObect = new System.IO.FileSystemWatcher();
            this.WatchedFolderLabel = new System.Windows.Forms.Label();
            this.AddFolderButton = new System.Windows.Forms.Button();
            this.watchedFolderList = new System.Windows.Forms.ListBox();
            this.DeleteFolderButton = new System.Windows.Forms.Button();
            this.CheckTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.fenêtreDinformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotificationSelectionGroup = new System.Windows.Forms.GroupBox();
            this.PermanentNotificationCheck = new System.Windows.Forms.RadioButton();
            this.TemporaryNotificationCheck = new System.Windows.Forms.RadioButton();
            this.NoNotificationCheck = new System.Windows.Forms.RadioButton();
            this.AutoHideOnStartup = new System.Windows.Forms.CheckBox();
            this.watchedFolderModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TimeDelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SystemTrayContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderWatcherObect)).BeginInit();
            this.MenuPrincipal.SuspendLayout();
            this.NotificationSelectionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchedFolderModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDelayUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "FileLookup";
            this.notifyIcon.BalloonTipTitle = "FileLookup";
            this.notifyIcon.ContextMenuStrip = this.SystemTrayContextMenu;
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // SystemTrayContextMenu
            // 
            this.SystemTrayContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SystemTrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowInformationMenuItem,
            this.ShowConfigurationMenuItem,
            this.toolStripSeparator1,
            this.ExitApplicationMenuItem});
            this.SystemTrayContextMenu.Name = "SystemTrayContextMenu";
            this.SystemTrayContextMenu.Size = new System.Drawing.Size(207, 100);
            // 
            // ShowInformationMenuItem
            // 
            this.ShowInformationMenuItem.Name = "ShowInformationMenuItem";
            this.ShowInformationMenuItem.Size = new System.Drawing.Size(206, 30);
            this.ShowInformationMenuItem.Text = "Informations";
            this.ShowInformationMenuItem.Click += new System.EventHandler(this.ShowInformationMenuItem_Click);
            // 
            // ShowConfigurationMenuItem
            // 
            this.ShowConfigurationMenuItem.Name = "ShowConfigurationMenuItem";
            this.ShowConfigurationMenuItem.Size = new System.Drawing.Size(206, 30);
            this.ShowConfigurationMenuItem.Text = "Configuration";
            this.ShowConfigurationMenuItem.Click += new System.EventHandler(this.ShowConfigurationMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // ExitApplicationMenuItem
            // 
            this.ExitApplicationMenuItem.Name = "ExitApplicationMenuItem";
            this.ExitApplicationMenuItem.Size = new System.Drawing.Size(206, 30);
            this.ExitApplicationMenuItem.Text = "Quitter";
            this.ExitApplicationMenuItem.Click += new System.EventHandler(this.ExitApplicationMenuItem_Click);
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
            this.WatchedFolderLabel.Location = new System.Drawing.Point(15, 16);
            this.WatchedFolderLabel.Name = "WatchedFolderLabel";
            this.WatchedFolderLabel.Size = new System.Drawing.Size(126, 20);
            this.WatchedFolderLabel.TabIndex = 0;
            this.WatchedFolderLabel.Text = "Watched Folder:";
            // 
            // AddFolderButton
            // 
            this.AddFolderButton.Location = new System.Drawing.Point(14, 179);
            this.AddFolderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddFolderButton.Name = "AddFolderButton";
            this.AddFolderButton.Size = new System.Drawing.Size(127, 41);
            this.AddFolderButton.TabIndex = 2;
            this.AddFolderButton.Text = "Ajouter";
            this.AddFolderButton.UseVisualStyleBackColor = true;
            this.AddFolderButton.Click += new System.EventHandler(this.AddFolderButton_Click);
            // 
            // watchedFolderList
            // 
            this.watchedFolderList.DisplayMember = "Path";
            this.watchedFolderList.FormattingEnabled = true;
            this.watchedFolderList.ItemHeight = 20;
            this.watchedFolderList.Location = new System.Drawing.Point(14, 46);
            this.watchedFolderList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.watchedFolderList.Name = "watchedFolderList";
            this.watchedFolderList.Size = new System.Drawing.Size(427, 124);
            this.watchedFolderList.TabIndex = 4;
            this.watchedFolderList.ValueMember = "Path";
            // 
            // DeleteFolderButton
            // 
            this.DeleteFolderButton.Location = new System.Drawing.Point(332, 179);
            this.DeleteFolderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteFolderButton.Name = "DeleteFolderButton";
            this.DeleteFolderButton.Size = new System.Drawing.Size(109, 41);
            this.DeleteFolderButton.TabIndex = 5;
            this.DeleteFolderButton.Text = "Retirer";
            this.DeleteFolderButton.UseVisualStyleBackColor = true;
            this.DeleteFolderButton.Click += new System.EventHandler(this.DeleteFolderButton_Click);
            // 
            // CheckTimer
            // 
            this.CheckTimer.Tick += new System.EventHandler(this.CheckTimer_Tick);
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fenêtreDinformationToolStripMenuItem});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MenuPrincipal.Size = new System.Drawing.Size(454, 33);
            this.MenuPrincipal.TabIndex = 6;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // fenêtreDinformationToolStripMenuItem
            // 
            this.fenêtreDinformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationsToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitterToolStripMenuItem});
            this.fenêtreDinformationToolStripMenuItem.Name = "fenêtreDinformationToolStripMenuItem";
            this.fenêtreDinformationToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.fenêtreDinformationToolStripMenuItem.Text = "Menu";
            // 
            // informationsToolStripMenuItem
            // 
            this.informationsToolStripMenuItem.Name = "informationsToolStripMenuItem";
            this.informationsToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.informationsToolStripMenuItem.Text = "Informations";
            this.informationsToolStripMenuItem.Click += new System.EventHandler(this.ShowInformationMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.ExitApplicationMenuItem_Click);
            // 
            // NotificationSelectionGroup
            // 
            this.NotificationSelectionGroup.Controls.Add(this.PermanentNotificationCheck);
            this.NotificationSelectionGroup.Controls.Add(this.TemporaryNotificationCheck);
            this.NotificationSelectionGroup.Controls.Add(this.NoNotificationCheck);
            this.NotificationSelectionGroup.Location = new System.Drawing.Point(19, 244);
            this.NotificationSelectionGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NotificationSelectionGroup.Name = "NotificationSelectionGroup";
            this.NotificationSelectionGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NotificationSelectionGroup.Size = new System.Drawing.Size(421, 78);
            this.NotificationSelectionGroup.TabIndex = 7;
            this.NotificationSelectionGroup.TabStop = false;
            this.NotificationSelectionGroup.Text = "Notification";
            // 
            // PermanentNotificationCheck
            // 
            this.PermanentNotificationCheck.AutoSize = true;
            this.PermanentNotificationCheck.Location = new System.Drawing.Point(244, 28);
            this.PermanentNotificationCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PermanentNotificationCheck.Name = "PermanentNotificationCheck";
            this.PermanentNotificationCheck.Size = new System.Drawing.Size(121, 24);
            this.PermanentNotificationCheck.TabIndex = 2;
            this.PermanentNotificationCheck.TabStop = true;
            this.PermanentNotificationCheck.Text = "Permanente";
            this.PermanentNotificationCheck.UseVisualStyleBackColor = true;
            this.PermanentNotificationCheck.Click += new System.EventHandler(this.PermanentNotificationCheck_Click);
            // 
            // TemporaryNotificationCheck
            // 
            this.TemporaryNotificationCheck.AutoSize = true;
            this.TemporaryNotificationCheck.Location = new System.Drawing.Point(113, 28);
            this.TemporaryNotificationCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TemporaryNotificationCheck.Name = "TemporaryNotificationCheck";
            this.TemporaryNotificationCheck.Size = new System.Drawing.Size(114, 24);
            this.TemporaryNotificationCheck.TabIndex = 1;
            this.TemporaryNotificationCheck.TabStop = true;
            this.TemporaryNotificationCheck.Text = "Temporaire";
            this.TemporaryNotificationCheck.UseVisualStyleBackColor = true;
            this.TemporaryNotificationCheck.Click += new System.EventHandler(this.TemporaryNotificationCheck_Click);
            // 
            // NoNotificationCheck
            // 
            this.NoNotificationCheck.AutoSize = true;
            this.NoNotificationCheck.Location = new System.Drawing.Point(8, 28);
            this.NoNotificationCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NoNotificationCheck.Name = "NoNotificationCheck";
            this.NoNotificationCheck.Size = new System.Drawing.Size(89, 24);
            this.NoNotificationCheck.TabIndex = 0;
            this.NoNotificationCheck.TabStop = true;
            this.NoNotificationCheck.Text = "Aucune";
            this.NoNotificationCheck.UseVisualStyleBackColor = true;
            this.NoNotificationCheck.Click += new System.EventHandler(this.NoNotificationCheck_Click);
            // 
            // AutoHideOnStartup
            // 
            this.AutoHideOnStartup.AutoSize = true;
            this.AutoHideOnStartup.Location = new System.Drawing.Point(25, 370);
            this.AutoHideOnStartup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AutoHideOnStartup.Name = "AutoHideOnStartup";
            this.AutoHideOnStartup.Size = new System.Drawing.Size(260, 24);
            this.AutoHideOnStartup.TabIndex = 8;
            this.AutoHideOnStartup.Text = "Cacher la fenêtre au démarrage";
            this.AutoHideOnStartup.UseVisualStyleBackColor = true;
            this.AutoHideOnStartup.CheckedChanged += new System.EventHandler(this.AutoHideOnStartup_CheckedChanged);
            // 
            // watchedFolderModelBindingSource
            // 
            this.watchedFolderModelBindingSource.DataSource = typeof(FileLookout.WatchedFolder);
            // 
            // TimeDelayUpDown
            // 
            this.TimeDelayUpDown.Location = new System.Drawing.Point(179, 330);
            this.TimeDelayUpDown.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.TimeDelayUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeDelayUpDown.Name = "TimeDelayUpDown";
            this.TimeDelayUpDown.Size = new System.Drawing.Size(120, 26);
            this.TimeDelayUpDown.TabIndex = 9;
            this.TimeDelayUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Délais de rappel :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "minutes.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeDelayUpDown);
            this.Controls.Add(this.AutoHideOnStartup);
            this.Controls.Add(this.NotificationSelectionGroup);
            this.Controls.Add(this.MenuPrincipal);
            this.Controls.Add(this.DeleteFolderButton);
            this.Controls.Add(this.watchedFolderList);
            this.Controls.Add(this.AddFolderButton);
            this.Controls.Add(this.WatchedFolderLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "FileLookout";
            this.SystemTrayContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.folderWatcherObect)).EndInit();
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.NotificationSelectionGroup.ResumeLayout(false);
            this.NotificationSelectionGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchedFolderModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDelayUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.IO.FileSystemWatcher folderWatcherObect;
        private System.Windows.Forms.Button AddFolderButton;
        private System.Windows.Forms.Label WatchedFolderLabel;
        private System.Windows.Forms.ListBox watchedFolderList;
        private System.Windows.Forms.BindingSource watchedFolderModelBindingSource;
        private System.Windows.Forms.Button DeleteFolderButton;
        private System.Windows.Forms.Timer CheckTimer;
        private System.Windows.Forms.ContextMenuStrip SystemTrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowInformationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowConfigurationMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitApplicationMenuItem;
        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem fenêtreDinformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.GroupBox NotificationSelectionGroup;
        private System.Windows.Forms.RadioButton PermanentNotificationCheck;
        private System.Windows.Forms.RadioButton TemporaryNotificationCheck;
        private System.Windows.Forms.RadioButton NoNotificationCheck;
        private System.Windows.Forms.CheckBox AutoHideOnStartup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TimeDelayUpDown;
    }
}

