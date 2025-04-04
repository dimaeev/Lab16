using System;
using System.IO;

public class FileHandler
{
  private string folderPath;

  public FileHandler(string path)
  {
    folderPath = path;
  }

  public string[] GetTextFiles()
  {
    return Directory.GetFiles(folderPath, "*.txt");
  }

  public string ReadFile(string filePath)
  {
    return File.ReadAllText(filePath);
  }

  public void WriteFile(string filePath, string content)
  {
    File.WriteAllText(filePath, content);
  }
}