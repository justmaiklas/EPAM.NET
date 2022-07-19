using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public class FileSystemVisitor : IFileSystemVisitor
    {
        private readonly Options _options;
        private readonly Func<Folder, bool>? _folderFilter;
        private readonly Func<File, bool>? _fileFilter;
        public FileSystemVisitor(Options options)
        {
            _options = options;
        }
        public FileSystemVisitor(Options options, Func<Folder, bool> folderFilter) : this(options)
        {
            _folderFilter = folderFilter;
        }
        public FileSystemVisitor(Options options, Func<File, bool> fileFilter) : this(options)
        {
            _fileFilter = fileFilter;
        }
        public FileSystemVisitor(Options options, Func<Folder, bool> folderFilter, Func<File, bool> fileFilter) : this(options, folderFilter)
        {
            _fileFilter = fileFilter;
        }
        public event EventHandler<CustomEventArgs> StartVisitEvent;
        public event EventHandler<CustomEventArgs> FinishVisitEvent;
        public event EventHandler<CustomEventArgs> FileFoundEvent;
        public event EventHandler<CustomEventArgs> FolderFoundEvent;
        public event EventHandler<CustomEventArgs> FilteredFileFoundEvent;
        public event EventHandler<CustomEventArgs> FilteredFolderFoundEvent;
        protected virtual void OnStartVisit(CustomEventArgs e)
        {
            var raiseEvent = StartVisitEvent;
            if (raiseEvent == null) return;
            e.Message += $"Started at {DateTime.Now}";
            raiseEvent(this, e);
        }
        protected virtual void OnFinishVisit(CustomEventArgs e)
        {
            var raiseEvent = FinishVisitEvent;
            if (raiseEvent == null) return;
            e.Message += $"Finished at {DateTime.Now}";
            raiseEvent(this, e);
        }
        protected virtual void OnFileFound(CustomEventArgs e)
        {
            var raiseEvent = FileFoundEvent;
            if (raiseEvent == null) return;
            e.Message = $"Found file {e.Message} at {DateTime.Now}";

            raiseEvent(this, e);
        }
        protected virtual void OnFolderFound(CustomEventArgs e)
        {
            var raiseEvent = FolderFoundEvent;
            if (raiseEvent == null) return;
            e.Message = $"Found folder {e.Message} at {DateTime.Now}";
            raiseEvent(this, e);
        }

        protected virtual void OnFilteredFileFound(CustomEventArgs e)
        {
            var raiseEvent = FilteredFileFoundEvent;
            if (raiseEvent == null) return;
            e.Message = $"Found filtered file {e.Message} at {DateTime.Now}";

            raiseEvent(this, e);
        }
        protected virtual void OnFilteredFolderFound(CustomEventArgs e)
        {
            var raiseEvent = FilteredFolderFoundEvent;
            if (raiseEvent == null) return;
            e.Message = $"Found filtered folder {e.Message} at {DateTime.Now}";
            
            raiseEvent(this, e);
        }
        public string[] GetFoldersStringArray(string path)
        {
            return Directory.GetDirectories(path, _options.SearchPattern, _options.SearchOptions);
        }

        public string[] GetFilesStringArray(string path)
        {
            return Directory.GetFiles(path, _options.SearchPattern, _options.SearchOptions);
        }

        public IEnumerable<Folder> GetFolders(string path)
        {
            var folders = GetFoldersStringArray(path);
            foreach (var directory in folders)
            {
                var folderInfo = new DirectoryInfo(directory);

                var folder = new Folder()
                {
                    FolderName = folderInfo.Name,
                    FullPath = folderInfo.FullName,
                };
                OnFolderFound(new CustomEventArgs(folder.FolderName));

                yield return folder;
            }
        }

        public IEnumerable<File> GetFiles(string path)
        {
            foreach (var file in GetFilesStringArray(path))
            {
                var fileInfo = new FileInfo(file);
                var fileToAdd = new File()
                {
                    FileName = fileInfo.Name
                };
                OnFileFound(new CustomEventArgs(fileToAdd.FileName));

                yield return fileToAdd;
            }
        }

        public IEnumerable<Folder> GetFilteredFolders(ICollection<Folder> folders)
        {
            foreach (var folder in folders)
            {
                if (_folderFilter != null && !_folderFilter(folder)) continue;
                OnFilteredFolderFound(new CustomEventArgs(folder.FolderName));

                yield return folder;
            }
        }

        public IEnumerable<File> GetFilteredFiles(ICollection<File> files)
        {
            foreach (var file in files)
            {
                if (_fileFilter != null && !_fileFilter(file)) continue;
                OnFilteredFileFound(new CustomEventArgs(file.FileName));

                yield return file;
            }
        }

        

    }
}
