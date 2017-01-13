using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileLookout
{
    public partial class NotificationForm : Form
    {
        protected List<WatchedFile> fileNotifications = new List<WatchedFile>();

        public NotificationForm()
        {
            InitializeComponent();

            FilesDetectedBinding.DataSource = fileNotifications;
            FilesDetectedList.DataSource = FilesDetectedBinding;
        }

        public void AddFile(WatchedFile f)
        {
            fileNotifications.Add(f);
            FilesDetectedBinding.ResetBindings(false);
        }
    }
}
