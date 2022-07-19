using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public class FileSystemVisitorOLD
    {
        private readonly Options _options;
        private readonly Func<Folder, bool>? _folderFilter;
        private readonly Func<File, bool>? _fileFilter;
        private readonly Func<Folder, File, bool> _folderFileFilter;


        public FileSystemVisitorOLD(Options options)
        {
            _options = options;
        }
        public FileSystemVisitorOLD(Options options, Func<Folder, bool> folderFilter) : this(options)
        {
            _folderFilter = folderFilter;
        }
        public FileSystemVisitorOLD(Options options, Func<File, bool> fileFilter) : this(options)
        {
            _fileFilter = fileFilter;
        }
        public FileSystemVisitorOLD(Options options, Func<Folder,bool> folderFilter, Func<File, bool> fileFilter) : this(options, folderFilter)
        {
            _fileFilter = fileFilter;
        }
        public FileSystemVisitorOLD(Options options, Func<Folder, File, bool> folderFileFilter) : this(options)
        {
            _folderFileFilter = folderFileFilter;
        }

        public event EventHandler<CustomEventArgs> StartVisitEvent;
        public event EventHandler<CustomEventArgs> FinishVisitEvent;
        public event EventHandler<CustomEventArgs> FileFoundEvent;
        public event EventHandler<CustomEventArgs> FolderFoundEvent;
        protected virtual void OnStartVisit(CustomEventArgs e)
        {
            var raiseEvent = StartVisitEvent;
            e.Message += $" at {DateTime.Now}";
            raiseEvent(this, e);
        }
        protected virtual void OnFinishVisit(CustomEventArgs e)
        {
            var raiseEvent = FinishVisitEvent;
            e.Message += $" at {DateTime.Now}";
            raiseEvent(this, e);
        }
        protected virtual void OnFileFound(CustomEventArgs e)
        {
            var raiseEvent = FileFoundEvent;

            raiseEvent(this, e);
        }
        protected virtual void OnFolderFound(CustomEventArgs e)
        {
            var raiseEvent = FolderFoundEvent;
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
            var allFolders = new List<Folder>();
            var allFiles = new List<File>();
            GetFolderData(rootFolder, allFolders, allFiles);
            OnFinishVisit(new CustomEventArgs("\nFinished visiting. Filtering.."));
            Filter(allFolders, allFiles);
            Console.WriteLine("Done");

        }

        private void Filter(List<Folder> allFolders, List<File> allFiles)
        {
            if (_options.SearchFlag == SearchFlag.Exclude)
            {
                if (_folderFilter != null)
                {
                    allFolders = allFolders.Where(folder => !_folderFilter(folder)).ToList();
                }
                if (_fileFilter != null)
                {
                    allFiles = allFiles.Where(file => !_fileFilter(file)).ToList();
                }
                return;
            }

        }


        private void GetFolderData(Folder rootFolder, ICollection<Folder> allFolders, List<File> allFiles)
        {
            GetCurrentDirectoryFiles(rootFolder, allFiles);
            foreach (var subFolder in GetSubFolders(rootFolder))
            {
                OnFolderFound(new CustomEventArgs(subFolder.FolderName));
                GetCurrentDirectoryFiles(subFolder, allFiles);
                GetFolderData(subFolder, allFolders, allFiles);
                rootFolder.SubFolders.Add(subFolder);
                allFolders.Add(subFolder);

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

        private void GetCurrentDirectoryFiles(Folder rootFolder, List<File> allFiles)
        {
            var folderFiles = Directory.GetFiles(rootFolder.FullPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in folderFiles)
            {
                var fileInfo = new FileInfo(file);
                var fileToAdd = new File(){FileName = fileInfo.Name, ParentFolder = rootFolder };
                OnFileFound(new CustomEventArgs(fileToAdd.FileName));

                rootFolder.Files.Add(fileToAdd);
                allFiles.Add(fileToAdd);
            }
        }
    }
}
