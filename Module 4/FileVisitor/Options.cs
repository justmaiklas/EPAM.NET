using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisitor
{
    public class Options
    {
        public static string BasePath => GetProjectPath();

        public static string GetProjectPath()
        {
            var currentDirectory = System.Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent;
            
            return projectDirectory.FullName;
        }
    }
}
