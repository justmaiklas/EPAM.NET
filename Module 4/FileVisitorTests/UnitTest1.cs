using System;
using System.Linq;
using FileVisitor;
using Xunit;
using static Xunit.Assert;

namespace FileVisitorTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetsAllFolders()
        {
            //Arrange
            var options = new Options();
            var _fileVisitor = new FileSystemVisitor(options);

            //Act
            var result = _fileVisitor.GetFolders(options.GetProjectPath());
            //Assert
            Equal(2, result.ToList().Count);
        }

        [Fact]
        public void GetsAllFiles()
        {
            //Arrange
            var options = new Options();
            var _fileVisitor = new FileSystemVisitor(options);

            //Act
            var result = _fileVisitor.GetFiles(options.GetProjectPath());
            //Assert
            Equal(2, result.ToList().Count);
        }

        [Fact]
        public void GetsAllFilteredFiles()
        {
            //Arrange
            var options = new Options();
            var filter = new Func<File, bool>(file => file.FileName.Contains("subfolderFile.txt"));
            var _fileVisitor = new FileSystemVisitor(options, filter);

            //Act
            var files = _fileVisitor.GetFiles(options.GetProjectPath());
            var filteredFiles = _fileVisitor.GetFilteredFiles(files.ToList());
            var result = filteredFiles.ToList();
            //Assert
            Assert.Equal(true, result.Any(file => file.FileName == "subfolderFile.txt"));
            Equal(1, result.Count);
        }

        [Fact]
        public void GetsAllFilteredFolders()
        {
            //Arrange
            var options = new Options();
            var filter = new Func<Folder, bool>(file => file.FolderName.Contains("Empty"));
            var _fileVisitor = new FileSystemVisitor(options, filter);

            //Act
            var folders = _fileVisitor.GetFolders(options.GetProjectPath());
            var filteredFolders = _fileVisitor.GetFilteredFolders(folders.ToList());
            var result = filteredFolders.ToList();
            //Assert
            Assert.Equal(true, result.Any(folder => folder.FolderName == "Empty"));
            Equal(1, result.Count);
        }

        [Fact]
        public void BothFiltersWorkWhenPassed()
        {
            //Arrange
            var options = new Options();
            var folderFilter = new Func<Folder, bool>(file => file.FolderName.Contains("Empty"));
            var fileFilter = new Func<File, bool>(file => file.FileName.Contains("subfolderFile.txt"));

            var fileVisitor = new FileSystemVisitor(options, folderFilter, fileFilter);

            //Act
            var files = fileVisitor.GetFiles(options.GetProjectPath());
            var filteredFiles = fileVisitor.GetFilteredFiles(files.ToList());
            var resultFiles = filteredFiles.ToList();
            var folders = fileVisitor.GetFolders(options.GetProjectPath());
            var filteredFolders = fileVisitor.GetFilteredFolders(folders.ToList());
            var resultFolders = filteredFolders.ToList();

            //Assert
            Equal(true, resultFiles.Any(file => file.FileName == "subfolderFile.txt"));
            Equal(1, resultFiles.Count);
            Equal(true, resultFolders.Any(folder => folder.FolderName == "Empty"));
            Equal(1, resultFolders.Count);

        }

        [Fact]
        public void FileFoundEventRaised()
        {
            var options = new Options();
            var fileVisitor = new FileSystemVisitor(options);
            var filesToFind = new string[] {"subfolderFile.txt", "rootFile.txt"};
            var actualMessage = "";
            fileVisitor.FileFoundEvent += delegate(object _, CustomEventArgs e) { actualMessage = e.Message; };
            var files = fileVisitor.GetFiles(options.GetProjectPath());
            foreach (var file in files)
            {
                True(filesToFind.Any(actualMessage.Contains));
            }
        }

        [Fact]
        public void FolderFoundEventRaised()
        {
            var options = new Options();
            var fileVisitor = new FileSystemVisitor(options);
            var foldersToFind = new[] {"Subfolder", "Empty"};
            var actualMessage = "";
            fileVisitor.FolderFoundEvent += delegate(object _, CustomEventArgs e) { actualMessage = e.Message; };
            var folders = fileVisitor.GetFolders(options.GetProjectPath());
            foreach (var folder in folders)
            {
                True(foldersToFind.Any(actualMessage.Contains));

            }
        }

        [Fact]
        public void FilteredFilesEventRaised()
        {
            //Arrange
            var options = new Options();
            var filter = new Func<File, bool>(file => file.FileName.Contains("subfolderFile.txt"));
            var fileVisitor = new FileSystemVisitor(options, filter);
            var actualMessage = "";
            fileVisitor.FilteredFileFoundEvent += delegate(object _, CustomEventArgs e) { actualMessage = e.Message; };

            //Act
            var files = fileVisitor.GetFiles(options.GetProjectPath());
            var filteredFiles = fileVisitor.GetFilteredFiles(files.ToList());


            //Assert
            foreach (var file in filteredFiles)
            {
                True(actualMessage.Contains("subfolderFile.txt"));
            }
        }

        [Fact]
        public void FilteredFolderEventRaised()
        {
            //Arrange
            var options = new Options();
            var filter = new Func<Folder, bool>(file => file.FolderName.Contains("Empty"));
            var _fileVisitor = new FileSystemVisitor(options, filter);
            var actualMessage = "";
            _fileVisitor.FilteredFolderFoundEvent += delegate(object _, CustomEventArgs e)
            {
                actualMessage = e.Message;
            };

            //Act
            var folders = _fileVisitor.GetFolders(options.GetProjectPath());
            var filteredFolders = _fileVisitor.GetFilteredFolders(folders.ToList());
            //Assert
            foreach (var folder in filteredFolders)
            {
                True(actualMessage.Contains("Empty"));
            }

        }
    }
}