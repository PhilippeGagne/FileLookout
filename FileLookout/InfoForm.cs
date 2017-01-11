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

        public InfoForm(List<WatchedFolder> items)
        {
            watchedFolders = items;

            InitializeComponent();

            // Connecte les données avec l'affichage des répertoires.
            watchedFoldersBinding.DataSource = watchedFolders;
            FolderInfoList.DataSource = watchedFoldersBinding;
            FolderInfoList.DisplayMember = "DisplayState";
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
        }
    }
}
