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
        // Données pour l'application
        private List<WatchedFolder> watchedFolders = new List<WatchedFolder>();
        private List<WatchedFile> watchedFiles = new List<WatchedFile>();

        // Éléments UI
        private BindingSource watchedFoldersBinding = new BindingSource();

        private Icon notifyNothingIcon;
        private Icon notifySomethingIcon;
        // TODO: icone interrogation quand le répertoire n'est pas spécifié ou n'existe pas.

        private InfoForm informationForm = null;

        public MainForm()
        {
            InitializeComponent();

            // Fenêtre des informations.
            informationForm = new InfoForm(watchedFolders, watchedFiles);
            informationForm.Hide();

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
            UpdateData();

            notifyIcon.Icon = notifyNothingIcon;
            notifyIcon.Visible = true;

            UpdateSystemTrayIconTextAndIcon();
        }

        /// <summary>
        /// Mise à jour des informations de bindings pour toutes les fenêtres qui en utilisent.
        /// </summary>
        private void UpdateData()
        {
            watchedFoldersBinding.ResetBindings(false);
            informationForm.UpdateData();
        }

        private void AddFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;

            var result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                AddFolderToWatchList(fbd.SelectedPath);
                UpdateData();

                //// Sauvegarde des paramètres
                SaveParameters();
            }
        }

        private void DeleteFolderButton_Click(object sender, EventArgs e)
        {
            var selectedFolder = (WatchedFolder)watchedFolderList.SelectedItem;
            watchedFolders.Remove(selectedFolder);
            UpdateData();

            // Faut arrêter de watcher le répertoire.
            // TODO: Automatiser dans un destructeur, voir IDisposable.
            selectedFolder.Dispose();

            //// Sauvegarde des paramètres
            SaveParameters();
        }

        // This delegate enables asynchronous calls for processing Directory events.
        delegate void DirectoryWatcherEventDelegate(object sender, FileSystemEventArgs e);

        // Appelé lors de la détection de la création d'un fichier.
        private void folderWatcherObect_Created(object sender, FileSystemEventArgs e)
        {
            if (this.InvokeRequired)
            {
                DirectoryWatcherEventDelegate d = new DirectoryWatcherEventDelegate(folderWatcherObect_Created);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                UpdateSystemTrayIconTextAndIcon();

                var newFile = new WatchedFile {
                    Path = e.FullPath,
                    DateDetected = DateTime.Now,
                    DirectoryWatched = ((FileSystemWatcher)sender).Path
                };
                watchedFiles.Add(newFile);

                // Faire apparaître une notification temporaire.
                //      String filepath = System.IO.Path.GetDirectoryName(e.FullPath);
                //      String filename = System.IO.Path.GetFileName(e.FullPath);

                String title = "Nouveaux fichiers";
                String message = String.Format(
                    "De nouveaux fichiers sont apparus dans le répertoire {0}.\n\n{1}",
                    newFile.DirectoryName, newFile.FileName);

                notifyIcon.ShowBalloonTip(0, title, message, ToolTipIcon.Info);

                // Mise à jour des informations affichées.
                UpdateData();
            }
        }

        private void folderWatcherObect_Deleted(object sender, FileSystemEventArgs e)
        {
            if (this.InvokeRequired)
            {
                DirectoryWatcherEventDelegate d = new DirectoryWatcherEventDelegate(folderWatcherObect_Deleted);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                UpdateSystemTrayIconTextAndIcon();

                // Mise à jour des informations affichées.
                UpdateData();
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            ShowInfoWindow();
        }

        /// <summary>
        ///  Vérifie les répertoires surveillés et ajuste l'icône de notification en conséquence.
        /// </summary>
        /// TODO: Mauvais nom. Sert à ajuster l'icône et le texte de la zone de notification.
        private void UpdateSystemTrayIconTextAndIcon()
        {
            int fileCount = 0;

            // TODO: as-t'on besoin d'un try/catch ?

            foreach (var folder in watchedFolders)
            {
                if (!Directory.Exists(folder.Path))
                {
                    // Le répertoire n'existe plus.
                    // TODO: avertir l'usager.
                    // UpdateData();
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
                text = "FileLookup: aucun répertoire spécifié.";
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
                    text = String.Format("FileLookup: un seul fichier.");
                else
                    text = String.Format("FileLookup: {0} fichiers.", fileCount);
            }

            notifyIcon.Text = text;
        }

        /// <summary>
        ///  Vérifie les répertoires surveillés et ajuste l'icône de notification en conséquence.
        /// </summary>
        private void ShowInfoWindow()
        {
            // Mise à jour des informations.
            UpdateData();

            // S'assure que la fenêtre est visible.
            FormWindowState previousWindowState = informationForm.WindowState;

            if (previousWindowState == FormWindowState.Minimized)
                informationForm.WindowState = FormWindowState.Normal;

            //            informationForm.WindowState = FormWindowState.Minimized;
            informationForm.Show();
            informationForm.Activate();

//            informationForm.WindowState = FormWindowState.Normal;

//            if (previousWindowState == FormWindowState.Maximized)
//                informationForm.WindowState = FormWindowState.Maximized;

            // get our current "TopMost" value (ours will always be false though)
//            bool top = informationForm.TopMost;
            // make our form jump to the top of everything
//            informationForm.TopMost = true;
            // set it back to whatever it was
 //           informationForm.TopMost = top;
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            UpdateSystemTrayIconTextAndIcon();
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
