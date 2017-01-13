using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileLookout
{
    public class WatchedFolder : IDisposable
    {
        /// <summary>
        /// Répertoire à surveiller.
        /// </summary>
        public String Path
        {
            get { return WatcherObject.Path; }
            set { WatcherObject.Path = value; }
        }

        /// <summary>
        /// Nombre de fichiers dans le réépertoire.
        /// </summary>
        public int FileCount
        {
            get
            {
                int count;
                if (Path.Count() > 0 && Directory.Exists(Path))
                {
                    count = Directory.EnumerateFileSystemEntries(Path).Count();
                }
                else
                {
                    count = 0;
                }

                return count;
            }
        }

        /// <summary>
        /// Retourne true si le répertoire est vide.
        /// </summary>
        public bool Empty
        {
            get{ return !Directory.EnumerateFileSystemEntries(Path).Any(); }
        }

        public bool Exists
        {
            get { return Path.Count() > 0 && Directory.Exists(Path); }
        }

        public string DisplayState
        {
            get
            {
                int nbrFiles = FileCount;

                if (nbrFiles == 0)
                {
                    return string.Format("{0} (aucun fichier)", Path);
                }
                else if (nbrFiles == 1)
                {
                    return string.Format("{0} (1 fichier)", Path);
                }
                else if (nbrFiles > 1)
                {
                    return string.Format("{0} ({1} fichiers)", Path, nbrFiles);
                }
                else
                {
                    // On ne devrait jamais passer par ici.
                    return string.Format("{0} (erreur: {1} fichiers)", Path, nbrFiles);
                }
            }
        }

        /// <summary>
        /// L'objet qui surveille le répertoire.
        /// </summary>
        public FileSystemWatcher WatcherObject { get; set; }

        public WatchedFolder()
        {
            WatcherObject = new FileSystemWatcher();
        }

        public void Dispose()
        {
            WatcherObject.EnableRaisingEvents = false;
            WatcherObject.Dispose();
        }

    }
}
