namespace FileVisitor;

public class File
{
    public File(string fileName, Folder parentFolder)
    {
        FileName = fileName;
        ParentFolder = parentFolder;
    }

    public string FileName { get; set; }
    public Folder ParentFolder { get; set; }
}