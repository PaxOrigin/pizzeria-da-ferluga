using FileSystemManager.Abstract;

namespace FileSystemManager.Concrete;

public class FileRepository : IFileRepository
{

    private string _mainDirectoryPath;

    public DirectoryInfo MainDirectory { get; private set; }
    public DirectoryInfo UnprocessedOrders { get; private set; }
    public DirectoryInfo ProcessedOrders { get; private set; }
    public DirectoryInfo Receipts { get; private set; }

    public FileRepository(string mainPath)
    {
        _mainDirectoryPath = Directory.Exists(mainPath) ? mainPath : Path.GetTempPath();
        MainDirectory = Directory.CreateDirectory(Path.Combine(_mainDirectoryPath, "FerlugaPizzeria"));
        UnprocessedOrders = Directory.CreateDirectory(Path.Combine(MainDirectory.FullName, "Unprocessed Orders"));
        ProcessedOrders = Directory.CreateDirectory(Path.Combine(MainDirectory.FullName, "Processed Orders"));
        Receipts = Directory.CreateDirectory(Path.Combine(MainDirectory.FullName, "Receipts"));
    }

    public string GetFolderMainPath() => MainDirectory.FullName;
}
