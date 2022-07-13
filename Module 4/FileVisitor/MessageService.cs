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
        }

        private void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"received this message: {e.Message}");
        }
    }
}
