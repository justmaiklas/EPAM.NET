using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public class FileSystemVisitor
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
        protected virtual void OnStartVisit(CustomEventArgs e)
        {
            var raiseEvent = StartVisitEvent;
            if (raiseEvent == null) return;
            e.Message += $" at {DateTime.Now}";
            raiseEvent(this, e);
        }
        protected virtual void OnFinishVisit(CustomEventArgs e)
        {
            var raiseEvent = FinishVisitEvent;
            if (raiseEvent == null) return;
            e.Message += $" at {DateTime.Now}";
            raiseEvent(this, e);
        }

        public void StartVisit()
        {
            OnStartVisit(new CustomEventArgs("Started visiting"));
            var rootFolder = new Folder
            {
                FolderName = "root",
                FullPath = _options.BasePath

            };
            GetFolderData(rootFolder);
            Console.WriteLine("Done");
            OnFinishVisit(new CustomEventArgs("Finished visiting"));

        }
        private void GetFolderData(Folder rootFolder)
        {
            GetCurrentDirectoryFiles(rootFolder);
            foreach (var subFolder in GetSubFolders(rootFolder))
            {
                GetCurrentDirectoryFiles(subFolder);
                GetFolderData(subFolder);
                rootFolder.SubFolders.Add(subFolder);

            }

        }

        private IEnumerable<Folder> GetSubFolders(Folder rootFolder)
        {
            var subFoldersArray = Directory.GetDirectories(rootFolder.FullPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var directory in subFoldersArray)
            {
                var folderInfo = new DirectoryInfo(directory);
                
                var subFolderToAdd = new Folder()
                {
                    FolderName = folderInfo.Name,
                    FullPath = folderInfo.FullName,
                    ParentFolder = rootFolder
                };


                if (_folderFilter != null && !_folderFilter(subFolderToAdd))
                {
                    continue;
                }

                yield return subFolderToAdd;
            }
        }

        private void GetCurrentDirectoryFiles(Folder rootFolder)
        {
            var folderFiles = Directory.GetFiles(rootFolder.FullPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in folderFiles)
            {
                var fileInfo = new FileInfo(file);
                var fileToAdd = new File(fileInfo.Name, rootFolder);
                if (_fileFilter != null && !_fileFilter(fileToAdd))
                {
                    continue;
                }
                rootFolder.Files.Add(fileToAdd);
            }
        }
    }
}
