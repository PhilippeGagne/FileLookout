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

        // Type de notification
        public enum NotificationType {
            NoNotification = 0,
            TemporaryNotification = 1,
            PermanentNotification = 2
        };
        private NotificationType notificationType = NotificationType.TemporaryNotification;

        // Cacher la fenêtre au démarrage.
        private bool hideFormOnStartup = false;

        // Fenêtre d'information (liste des répertoires observés)
        private InfoForm informationForm = null;

        // Fenêtre pour la notification «permanente». On la créée la première fois qu'on en a besoin.
        private NotificationForm permanentNotificationForm = null;

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

            hideFormOnStartup = Properties.Settings.Default.hideFormOnStartup;
            AutoHideOnStartup.Checked = hideFormOnStartup;
            if (hideFormOnStartup)
                Visible = false;
            else
            {
                //Opacity = 100;
                //ShowInTaskbar = true;
                Visible = true;
            }

            // Répertoires observés
            foreach (var folder in Properties.Settings.Default.watchedFolders)
            {
                AddFolderToWatchList(folder);
            }
            UpdateData();

            // Radios buttons
            if (Properties.Settings.Default.notificationType == NotificationType.NoNotification.ToString() )
            {
                notificationType = NotificationType.NoNotification;
                NoNotificationCheck.Checked = true;
            }
            else if (Properties.Settings.Default.notificationType == NotificationType.TemporaryNotification.ToString())
            {
                notificationType = NotificationType.TemporaryNotification;
                TemporaryNotificationCheck.Checked = true;
            }
            else if (Properties.Settings.Default.notificationType == NotificationType.PermanentNotification.ToString())
            {
                notificationType = NotificationType.PermanentNotification;
                PermanentNotificationCheck.Checked = true;
            }
            else
            {
                notificationType = NotificationType.TemporaryNotification;
                TemporaryNotificationCheck.Checked = true;
            }

            notifyIcon.Icon = notifyNothingIcon;
            notifyIcon.Visible = true;

            permanentNotificationForm = new NotificationForm();
            // Il faut la faire apparaître, sinon tout va tout croche (on dirait qu'elle
            // est maal gérée par Windows. On a cependant overidé NotificationForm::SetVisibleCore
            // pour qu'elle reste invisible le premier «Show».
            permanentNotificationForm.Show();


            UpdateSystemTrayIconTextAndIcon();
        }

        /// <summary>
        /// On va avoir une seule fenêtre toujours ouverte. L'usager de la
        /// ferme pas mais il la cache.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveParameters();

            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
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
            if (watchedFolderList.InvokeRequired)
            {
                DirectoryWatcherEventDelegate d = new DirectoryWatcherEventDelegate(folderWatcherObect_Created);
                Invoke(d, new object[] { sender, e });
            }
            else
            {
                Debug.Assert(!InvokeRequired);

                UpdateSystemTrayIconTextAndIcon();

                // Prend en note le fichier ajouté.
                var newFile = new WatchedFile {
                    Path = e.FullPath,
                    DateDetected = DateTime.Now,
                    DirectoryWatched = ((FileSystemWatcher)sender).Path
                };
                watchedFiles.Add(newFile);

                if (notificationType == NotificationType.TemporaryNotification)
                {
                    // Faire apparaître une notification temporaire.
                    String title = "Nouveaux fichiers";
                    String message = String.Format(
                        "De nouveaux fichiers sont apparus dans le répertoire {0}.\n\n{1}",
                        newFile.DirectoryName, newFile.FileName);

                    notifyIcon.ShowBalloonTip(0, title, message, ToolTipIcon.Info);
                }
                else if (notificationType == NotificationType.PermanentNotification)
                {
                    permanentNotificationForm.AddFile(newFile);
                }
               
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
            // On doit faire la différence entre les boutons de la souris.
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
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

            MakeFormVisible(informationForm);
        }

        private void MakeFormVisible(Form f)
        {
            // S'assure que la fenêtre est visible.
            FormWindowState previousWindowState = f.WindowState;

            if (previousWindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;

            //            f.WindowState = FormWindowState.Minimized;
            f.Show();
            f.Activate();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
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
            Properties.Settings.Default.hideFormOnStartup = hideFormOnStartup;

            // Les répertoires observés.
            Properties.Settings.Default.watchedFolders.Clear();

            foreach (var folder in watchedFolders)
            {
                Properties.Settings.Default.watchedFolders.Add(folder.Path);
            }

            // Le type de notification
            Properties.Settings.Default.notificationType = notificationType.ToString();

            // Sauvegarde.
            Properties.Settings.Default.Save();
        }

        private void ShowInformationMenuItem_Click(object sender, EventArgs e)
        {
            ShowInfoWindow();
        }

        private void ShowConfigurationMenuItem_Click(object sender, EventArgs e)
        {
            MakeFormVisible(this);
        }

        private void ExitApplicationMenuItem_Click(object sender, EventArgs e)
        {
            // On doit passer par Exit puisqu'on trappe le close et qu'on l'a transformé
            // en Hide.
            Application.Exit();
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
//            UpdateSystemTrayIconTextAndIcon();
        }

        
        private void NoNotificationCheck_Click(object sender, EventArgs e)
        {
            notificationType = NotificationType.NoNotification;
        }

        private void AutoHideOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            hideFormOnStartup = AutoHideOnStartup.Checked;
        }

        private void TemporaryNotificationCheck_Click(object sender, EventArgs e)
        {
            notificationType = NotificationType.TemporaryNotification;
        }

        private void PermanentNotificationCheck_Click(object sender, EventArgs e)
        {
            notificationType = NotificationType.PermanentNotification;
        }
    }
}
