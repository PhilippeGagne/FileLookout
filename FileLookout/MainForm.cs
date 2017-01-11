using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileLookout
{
    public partial class MainForm : Form
    {
        private string watchedFolderPath;

        private Icon notifyNothingIcon;
        private Icon notifySomethingIcon;
        // TODO: icone interrogation quand le répertoire n'est pas spécifié ou n'existe pas.

        public MainForm()
        {
            InitializeComponent();

            notifyNothingIcon = ((System.Drawing.Icon)(Properties.Resources.FileLookoutIcon));
            notifySomethingIcon = ((System.Drawing.Icon)(Properties.Resources.FileLookoutExclamationIcon));

            watchedFolderPath = Properties.Settings.Default.watchedFolder;
            SetupFolderWatching(watchedFolderPath);

            notifyIcon.Icon = notifyNothingIcon;
            notifyIcon.Visible = true;

            CheckWatchedFolderState();
        }

        private void WatchedFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (Directory.Exists(watchedFolderPath))
                fbd.SelectedPath = watchedFolderPath;
            fbd.ShowNewFolderButton = false;

            var result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                watchedFolderPath = fbd.SelectedPath;

                SetupFolderWatching(watchedFolderPath);

                // Sauvegarde des paramètres
                // TODO: Mettre ailleurs ?
                Properties.Settings.Default.watchedFolder = watchedFolderPath;
                Properties.Settings.Default.Save();
            }
        }

        private void SetupFolderWatching(string watchedFolderPath)
        {
            WatchedFolderText.Text = watchedFolderPath;

            // Mise à jour de la surveillance du répertoire.
            folderWatcherObect.Path = watchedFolderPath;
        }

        // Appelé lors de la détection de la création s'un fichier.
        private void folderWatcherObect_Created(object sender, FileSystemEventArgs e)
        {
            CheckWatchedFolderState();

            notifyIcon.ShowBalloonTip(50000, "Nouveaux fichiers", "De nouveaux fichiers sont apparus dans le répertoire.", ToolTipIcon.Info);
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (watchedFolderPath.Length > 0 && Directory.Exists(watchedFolderPath))
            {
                Process.Start(watchedFolderPath);
            }
        }

        private void folderWatcherObect_Deleted(object sender, FileSystemEventArgs e)
        {
            CheckWatchedFolderState();
        }

        /// <summary>
        ///  Vérifie le contenu du répertoire surveillé et ajuste l'icône de notification en conséquence.
        /// </summary>
        private void CheckWatchedFolderState()
        {
            // TODO: as-t'on besoin d'un try/catch ?

            if (Directory.Exists(watchedFolderPath) && Directory.EnumerateFileSystemEntries(watchedFolderPath).Any())
            {
                // Le répertoire semble contenir des fichiers. 
                notifyIcon.Icon = notifySomethingIcon;

                notifyIcon.Text = string.Format("FileLookup\n\n{0}: {1} éléments.",
                    watchedFolderPath, 
                    Directory.EnumerateFileSystemEntries(watchedFolderPath).Count());
            }
            else
            {
                // Rien dans le répertoire.
                notifyIcon.Icon = notifyNothingIcon;

                notifyIcon.Text = string.Format("FileLookup\n\n{0}: aucun fichier.", watchedFolderPath);
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            // notifyIcon.
            //MessageBox.Show("test", "tester", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
    }
}
