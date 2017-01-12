using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileLookout
{
    public partial class InfoForm : Form
    {
        private List<WatchedFolder> watchedFolders;
        private BindingSource watchedFoldersBinding = new BindingSource();

        private List<WatchedFile> watchedFiles;
        private BindingSource watchedFilesBinding = new BindingSource();

        public InfoForm(List<WatchedFolder> items, List<WatchedFile> files)
        {
            watchedFolders = items;
            watchedFiles = files;

            InitializeComponent();

            // Connecte les données avec l'affichage des répertoires.
            watchedFoldersBinding.DataSource = watchedFolders;
            FolderInfoList.DataSource = watchedFoldersBinding;
            FolderInfoList.DisplayMember = "DisplayState";

            watchedFilesBinding.DataSource = watchedFiles;
            FileEventsDataView.DataSource = watchedFilesBinding;
        }

        private void FolderInfoList_DoubleClick(object sender, EventArgs e)
        {
            var selectedFolder = (WatchedFolder)FolderInfoList.SelectedItem;
            if (selectedFolder.Exists)
            {
                Process.Start(selectedFolder.Path);
            }
        }

        public void UpdateData()
        {
            watchedFoldersBinding.ResetBindings(false);
            watchedFilesBinding.ResetBindings(false);
        }

        /// <summary>
        /// On va avoir une seule fenêtre toujours ouverte. L'usager de la
        /// ferme pas mais il la cache.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void FileEventsDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
