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

            var fileSystemVisitor = new FileSystemVisitor(new Options(), (folder, file) => folder.FolderName == "bin" || file.FileName == "FileVisitor");
            var messageService = new MessageService(fileSystemVisitor);
            
            fileSystemVisitor.StartVisit();
        }

        
    }
}