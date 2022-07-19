using System;
using System.Collections;
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
            var options = new Options();
            var fileVisitor = new FileSystemVisitor(options);
            var messageService = new MessageService();

            fileVisitor.FilteredFolderFoundEvent += messageService.HandleCustomEvent;
            fileVisitor.FilteredFileFoundEvent += messageService.HandleCustomEvent;
            fileVisitor.FileFoundEvent += messageService.HandleCustomEvent;
            fileVisitor.FolderFoundEvent += messageService.HandleCustomEvent;
            fileVisitor.StartVisitEvent += messageService.HandleCustomEvent;
            fileVisitor.FinishVisitEvent += messageService.HandleCustomEvent;
            var allFolders = fileVisitor.GetFolders(options.BasePath).ToList();

            Console.WriteLine("Done");
            //var fileSystemVisitor = new FileSystemVisitor(new Options(), (folder, file) => folder.FolderName == "bin" || file.FileName == "FileVisitor");
            //var messageService = new MessageService(fileSystemVisitor);

            //fileSystemVisitor.StartVisit();
        }

        
    }
}