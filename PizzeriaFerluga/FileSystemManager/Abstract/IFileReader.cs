namespace FileSystemManager.Abstract
{
    public interface IFileReader
    {
        IEnumerable<string>? ReadFile(string filePath);
    }
}