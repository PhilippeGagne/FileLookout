namespace FileLookout
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FolderInfoList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // FolderInfoList
            // 
            this.FolderInfoList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderInfoList.FormattingEnabled = true;
            this.FolderInfoList.ItemHeight = 16;
            this.FolderInfoList.Location = new System.Drawing.Point(13, 13);
            this.FolderInfoList.Name = "FolderInfoList";
            this.FolderInfoList.Size = new System.Drawing.Size(1031, 500);
            this.FolderInfoList.TabIndex = 0;
            this.FolderInfoList.DoubleClick += new System.EventHandler(this.FolderInfoList_DoubleClick);
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 568);
            this.Controls.Add(this.FolderInfoList);
            this.Name = "InfoForm";
            this.Text = "Informations";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox FolderInfoList;
    }
}