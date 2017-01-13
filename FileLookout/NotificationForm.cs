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
        public delegate void AddFileDelegate(WatchedFile f);

        protected List<WatchedFile> fileNotifications = new List<WatchedFile>();

        public NotificationForm()
        {
            InitializeComponent();

            FilesDetectedBinding.DataSource = fileNotifications;
            dataGridView1.DataSource = FilesDetectedBinding;
        }

        // ref: http://stackoverflow.com/questions/5168249/c-showing-an-invisible-form
        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
                value = false;   // Prevent window from becoming visible
            }
            base.SetVisibleCore(value);
        }

        /// <summary>
        /// On va avoir une seule fenêtre toujours ouverte. L'usager de la
        /// ferme pas mais il la cache.
        /// 
        /// En même temps on efface la liste des avertissements.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            fileNotifications.Clear();
            FilesDetectedBinding.ResetBindings(false);

            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void AddFile(WatchedFile f)
        {
            if (InvokeRequired)
            {
                AddFileDelegate d = new AddFileDelegate(AddFile);
                Invoke(d, new object[] { f });

            }
            else
            {
                Show();
                Activate();
                //MakeFormVisible(this);
                //Application.DoEvents();

                fileNotifications.Add(f);
                FilesDetectedBinding.ResetBindings(false);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void MakeFormVisible(Form f)
        //{
        //    // S'assure que la fenêtre est visible.
        //    FormWindowState previousWindowState = f.WindowState;

        //    if (previousWindowState == FormWindowState.Minimized)
        //        f.WindowState = FormWindowState.Normal;

        //    //            f.WindowState = FormWindowState.Minimized;
        //    f.Show();
        //    f.Activate();
        //}
    }
}
