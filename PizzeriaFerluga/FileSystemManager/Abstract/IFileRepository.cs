namespace FileSystemManager.Concrete
{
    public interface IFileRepository
    {
        DirectoryInfo FailedOrders { get; }
        DirectoryInfo MainDirectory { get; }
        DirectoryInfo ProcessedOrders { get; }
        DirectoryInfo Receipts { get; }
        DirectoryInfo UnprocessedOrders { get; }

        string GetFolderMainPath();
        string GetReceiptFullPath(string filePath);
    }
}