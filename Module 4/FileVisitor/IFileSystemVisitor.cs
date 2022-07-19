using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public interface IFileSystemVisitor
    {

        public event EventHandler<CustomEventArgs> StartVisitEvent;
        public event EventHandler<CustomEventArgs> FinishVisitEvent;
        public event EventHandler<CustomEventArgs> FileFoundEvent;
        public event EventHandler<CustomEventArgs> FolderFoundEvent;
        public string[] GetFoldersStringArray(string path);
        public string[] GetFilesStringArray(string path);
        public IEnumerable<Folder> GetFolders(string path);
        public IEnumerable<File> GetFiles(string path);
        public IEnumerable<Folder> GetFilteredFolders(ICollection<Folder> folders);
        public IEnumerable<File> GetFilteredFiles(ICollection<File> files);
    }
}
