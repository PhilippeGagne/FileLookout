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
        /// On va avoir une seule fenêtre toujours ouverte. L'usager ne la
        /// ferme pas mais il la cache.
        /// 
        /// En même temps on efface la liste des avertissements.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
//            fileNotifications.Clear();
//            FilesDetectedBinding.ResetBindings(false);

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
                // On aura pas besoin du timer de recall, s'il est en fonction, puisqu'on
                // va popper la fenêtre.
                RecallTimer.Enabled = false;

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
            // Vide la liste des fichiers.

            fileNotifications.Clear();
            FilesDetectedBinding.ResetBindings(false);

            Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fileNotifications[e.RowIndex].OpenDir();
        }

        private void RecallTimer_Tick(object sender, EventArgs e)
        {
            RecallTimer.Enabled = false;

            // Par définition, l'appel sera sur le thread GUI.
            Show();
            Activate();
        }

        private void LaterButton_Click(object sender, EventArgs e)
        {
            RecallTimer.Enabled = true;
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
