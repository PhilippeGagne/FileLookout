using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FileLookout
{
    public class WatchedFile
    {
        public string Path { get; set; }

        public DateTime DateDetected { get; set; }

        public string FileName { get { return System.IO.Path.GetFileName(Path); } }

        public string DirectoryName { get { return System.IO.Path.GetDirectoryName(Path); } }

        public string DirectoryWatched { get; set; }

        public void OpenDir()
        {
            if (File.Exists(Path))
            {
                // combine the arguments together
                // it doesn't matter if there is a space after ','
                string argument = "/select, \"" + Path + "\"";

                Process.Start("explorer.exe", argument);
            }
            else if (Directory.Exists(DirectoryName))
            {
                // can appen if file was renamed.
                Process.Start(DirectoryName);
            }
            else
            {
                // User warning ?
            }
        }
    }
}
