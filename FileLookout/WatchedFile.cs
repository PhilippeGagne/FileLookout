using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileLookout
{
    public class WatchedFile
    {
        public string Path { get; set; }

        public DateTime DateDetected { get; set; }

        public string FileName { get { return System.IO.Path.GetFileName(Path); } }

        public string DirectoryName { get { return System.IO.Path.GetDirectoryName(Path); } }

        public string DirectoryWatched { get; set; }
    }
}
