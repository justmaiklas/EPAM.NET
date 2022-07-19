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
        public SearchFlag SearchFlag { get; }
        public readonly string SearchPattern = "*.*";
        public readonly SearchOption SearchOptions = SearchOption.AllDirectories;



        public Options(SearchFlag searchFlag = SearchFlag.IgnoreFlag)
        {
            BasePath = GetProjectPath();
            SearchFlag = searchFlag;
        }

        public Options(string basePath, SearchFlag searchFlag = SearchFlag.IgnoreFlag)
        {
            BasePath = basePath;
            SearchFlag = searchFlag;
        }


        public string GetProjectPath()
        {
            var currentDirectory = System.Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent;
            if (projectDirectory == null)
            {
                throw new ArgumentNullException();
            }
            
            return projectDirectory.FullName + "\\FolderTest";
        }
    }

    public enum SearchFlag
    {
        IgnoreFlag,
        Abort,
        Exclude
    }
}
