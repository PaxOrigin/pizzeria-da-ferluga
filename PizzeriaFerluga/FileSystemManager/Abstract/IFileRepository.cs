namespace FileSystemManager.Abstract
{
    public interface IFileRepository
    {
        DirectoryInfo MainDirectory { get; }
        DirectoryInfo ProcessedOrders { get; }
        DirectoryInfo Receipts { get; }
        DirectoryInfo UnprocessedOrders { get; }

        string GetFolderMainPath();
    }
}