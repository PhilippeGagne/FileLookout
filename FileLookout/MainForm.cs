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
        private List<WatchedFolder> watchedFolders = new List<WatchedFolder>();
        private BindingSource watchedFoldersBinding = new BindingSource();

        private Icon notifyNothingIcon;
        private Icon notifySomethingIcon;
        // TODO: icone interrogation quand le répertoire n'est pas spécifié ou n'existe pas.


        public MainForm()
        {
            InitializeComponent();

 //           dlg = new InfoForm(watchedFolders);

            // Connecte les données avec l'affichage des répertoires.
            watchedFoldersBinding.DataSource = watchedFolders;
            watchedFolderList.DataSource = watchedFoldersBinding;
            watchedFolderList.DisplayMember = "Path";

            notifyNothingIcon = ((System.Drawing.Icon)(Properties.Resources.FileLookoutIcon));
            notifySomethingIcon = ((System.Drawing.Icon)(Properties.Resources.FileLookoutExclamationIcon));

            foreach (var folder in Properties.Settings.Default.watchedFolders)
            {
                AddFolderToWatchList(folder);
            }
            watchedFoldersBinding.ResetBindings(false);

            notifyIcon.Icon = notifyNothingIcon;
            notifyIcon.Visible = true;

            CheckWatchedFolderState();
        }


        private void AddFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;

            var result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                AddFolderToWatchList(fbd.SelectedPath);
                watchedFoldersBinding.ResetBindings(false);

                //// Sauvegarde des paramètres
                SaveParameters();
            }
        }

        private void DeleteFolderButton_Click(object sender, EventArgs e)
        {
            var selectedFolder = (WatchedFolder)watchedFolderList.SelectedItem;
            watchedFolders.Remove(selectedFolder);
            watchedFoldersBinding.ResetBindings(false);

            // Faut arrêter de watcher le répertoire.
            // TODO: Automatiser dans un destructeur, voir IDisposable.
            selectedFolder.Dispose();

            //// Sauvegarde des paramètres
            SaveParameters();
        }

        // Appelé lors de la détection de la création s'un fichier.
        private void folderWatcherObect_Created(object sender, FileSystemEventArgs e)
        {
            CheckWatchedFolderState();

            String filepath = System.IO.Path.GetDirectoryName(e.FullPath);
            String filename = System.IO.Path.GetFileName(e.FullPath);

            String title = "Nouveaux fichiers";
            String message = String.Format("De nouveaux fichiers sont apparus dans le répertoire {0}.\n\n{1}",
                filepath, filename);
            
            notifyIcon.ShowBalloonTip(0, title, message, ToolTipIcon.Info);
        }

        private void folderWatcherObect_Deleted(object sender, FileSystemEventArgs e)
        {
            CheckWatchedFolderState();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            ShowInfoWindow();
        }

        /// <summary>
        ///  Vérifie les répertoires surveillés et ajuste l'icône de notification en conséquence.
        /// </summary>
        private void CheckWatchedFolderState()
        {
            int fileCount = 0;

            // TODO: as-t'on besoin d'un try/catch ?

            foreach (var folder in watchedFolders)
            {
                if (!Directory.Exists(folder.Path))
                {
                    // Le répertoire n'existe plus.
                    // TODO: avertir l'usager.
                }
                else if (!folder.Empty)
                {
                    fileCount += folder.FileCount;
                }
            }

            string text = "";
            if (watchedFolders.Count==0)
            {
                // Rien dans le répertoire.
                notifyIcon.Icon = notifyNothingIcon;
                text = "FileLookup: Aucun répertoire spécifié.";
            }
            else if (fileCount > 0)
            {
                // Rien dans le répertoire.
                notifyIcon.Icon = notifyNothingIcon;
                text = "FileLookup: aucun fichier.";
            }
            else if (fileCount>0)
            {
                notifyIcon.Icon = notifySomethingIcon;

                if (fileCount==1)
                    text = String.Format("FileLookup: un fichier trouvé.");
                else
                    text = String.Format("FileLookup: {0] fichiers trouvés.", fileCount);
            }

            notifyIcon.Text = text;
        }

        /// <summary>
        ///  Vérifie les répertoires surveillés et ajuste l'icône de notification en conséquence.
        /// </summary>
        private void ShowInfoWindow()
        {
            var dlg = new InfoForm(watchedFolders);
            dlg.ShowDialog();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            CheckWatchedFolderState();
            ShowInfoWindow();
        }

        /// <summary>
        /// Ajout le répertoire spécifié par «path» à la liste des répertoies.
        /// 
        /// NB: il faut ensuite appeler watchedFoldersBinding.ResetBindings(false);
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private WatchedFolder AddFolderToWatchList(string path)
        {
            WatchedFolder newWatchedFolder = null;
            // TODO: Verifier si le répertoire existe ?

            if (path.Length > 0 && Directory.Exists(path))
            {
                newWatchedFolder = new WatchedFolder { Path = path };
                watchedFolders.Add(newWatchedFolder);

                // TODO: aller dans une fonction newWatchedFolder ?
                newWatchedFolder.WatcherObject.Filter = "*.*";
                newWatchedFolder.WatcherObject.Created += new FileSystemEventHandler(folderWatcherObect_Created);
                newWatchedFolder.WatcherObject.Deleted += new FileSystemEventHandler(folderWatcherObect_Deleted);
                newWatchedFolder.WatcherObject.EnableRaisingEvents = true;
            }

            return newWatchedFolder;
        }

        private void SaveParameters()
        {
            Properties.Settings.Default.watchedFolders.Clear();

            foreach (var folder in watchedFolders)
            {
                Properties.Settings.Default.watchedFolders.Add(folder.Path);
            }

            Properties.Settings.Default.Save();
        }
    }
}
