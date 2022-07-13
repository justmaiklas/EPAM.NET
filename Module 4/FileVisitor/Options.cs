using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public class Options
    {
        public string BasePath { get; set; }
        

        public Options()
        {
            BasePath = GetProjectPath();
        }

        public Options(string basePath)
        {
            BasePath = basePath;
        }


        public string GetProjectPath()
        {
            var currentDirectory = System.Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent;
            if (projectDirectory == null)
            {
                throw new ArgumentNullException();
            }
            
            return projectDirectory.FullName;
        }
    }
}
