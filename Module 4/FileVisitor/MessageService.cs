using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public class MessageService
    {
        public MessageService(FileSystemVisitor _fileSystemVisitor)
        {
            _fileSystemVisitor.StartVisitEvent += HandleCustomEvent;
            _fileSystemVisitor.FinishVisitEvent += HandleCustomEvent;
            _fileSystemVisitor.FileFoundEvent += FileFoundHandler;
            _fileSystemVisitor.FolderFoundEvent += FolderFoundHandler;
        }

        private void FolderFoundHandler(object? sender, CustomEventArgs e)
        {
            Console.WriteLine($"Found Folder: {e.Message}");

        }

        private void FileFoundHandler(object? sender, CustomEventArgs e)
        {
            Console.WriteLine($"Found File: {e.Message}");

        }

        private void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
}
