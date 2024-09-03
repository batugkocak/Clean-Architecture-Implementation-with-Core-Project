namespace Core.CrossCuttingConcerns.Serilog;

public class FileLogConfiguration
{
    public FileLogConfiguration(string folderPath)
    {
        FolderPath = folderPath;
    }

    public FileLogConfiguration()
    {
        FolderPath = string.Empty;
    }
    public string FolderPath { get; set; }   
}