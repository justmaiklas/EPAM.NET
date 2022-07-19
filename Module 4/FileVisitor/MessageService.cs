using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public class MessageService
    {

        private void FolderFoundHandler(object? sender, CustomEventArgs e)
        {
            Console.WriteLine($"Found Folder: {e.Message}");

        }

        private void FileFoundHandler(object? sender, CustomEventArgs e)
        {
            Console.WriteLine($"Found File: {e.Message}");

        }

        public void HandleCustomEvent(object? sender, CustomEventArgs e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
}
