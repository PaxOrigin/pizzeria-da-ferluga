using FileSystemManager.Abstract;

namespace FileSystemManager.Concrete;


public class FileReader : IFileReader
{
    public IEnumerable<string>? ReadFile(string filePath)
        => File.ReadLines(filePath);

}