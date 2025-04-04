using System;
using System.IO;

class Program
{
  static void Main(string[] args)
  {
    string folderPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName;

    FileHandler fileHandler = new FileHandler(folderPath);
    TextProcessor textProcessor = new TextProcessor();

    string[] files = fileHandler.GetTextFiles();

    foreach (string file in files)
    {
      string text = fileHandler.ReadFile(file);

      text = textProcessor.CorrectMistakes(text);
      text = textProcessor.FixPhoneNumbers(text);

      fileHandler.WriteFile(file, text);

      Console.WriteLine($"Исправления внесены в файл: {file}");
    }
  }
}