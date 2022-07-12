namespace FileVisitor;

public class Folder
{
    //public Folder(List<File> files, List<Folder> subFolders, Folder parentFolder)
    //{
    //    Files = files;
    //    SubFolders = subFolders;
    //    ParentFolder = parentFolder;
    //}

    public Folder()
    {
        Files = new List<File>();
        SubFolders = new List<Folder>();
    }

    //public void SetFolderName(string folderName)
    //{
    //    FolderName = folderName;
    //}

    //public void AddFile(File fileToAdd)
    //{
    //    Files.Add(fileToAdd);
    //}
    //public void AddSubFolder(Folder subfolderToAdd)
    //{
    //    SubFolders.Add(subfolderToAdd);
    //}

    //public void SetParentFolder(Folder parentFolder)                     
    //{
    //    ParentFolder = parentFolder;
    //}

    //public void SetFullPath(string fullPath)
    //{
    //    FullPath = 
    //}

    public List<File> Files { get; set; }
    public List<Folder> SubFolders { get; set; }
    public Folder? ParentFolder { get; set; }
    public string FolderName { get; set; }
    public string FullPath { get; set; }

}