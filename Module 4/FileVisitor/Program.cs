using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public static class Program
    {
        public static void Main()
        {
            var rootFolder = new Folder
            {
                FolderName = "root",
                FullPath = Options.BasePath

            };
            rootFolder.GetFolderData();
            Console.WriteLine("Done");

        }

        public static void GetFolderData(this Folder rootFolder)
        {
            rootFolder.GetCurrentDirectoryFiles();
            foreach (var subFolder in GetSubFolders(rootFolder))
            {
                subFolder.GetCurrentDirectoryFiles();
                subFolder.GetFolderData();
                rootFolder.SubFolders.Add(subFolder);

            }

        }

        public static IEnumerable<Folder> GetSubFolders(this Folder rootFolder)
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
                yield return subFolderToAdd;

            }
        }

        public static void GetCurrentDirectoryFiles(this Folder rootFolder)
        {
            var folderFiles = Directory.GetFiles(rootFolder.FullPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in folderFiles)
            {
                var fileInfo = new FileInfo(file);
                var fileToAdd = new File(fileInfo.Name, rootFolder);
                
                rootFolder.Files.Add(fileToAdd);
            }
        }
    }
}