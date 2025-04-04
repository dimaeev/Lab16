using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
  static void Main(string[] args)
  {
    string folderPath = GetFolderPath();
    string[] files = GetTextFiles(folderPath);

    foreach (string file in files)
    {
      string text = File.ReadAllText(file);

      text = CorrectMistakes(text);

      text = FixPhoneNumbers(text);

      File.WriteAllText(file, text);

      Console.WriteLine($"Исправления внесены в файл: {file}");
    }
  }

  static string GetFolderPath()
  {
    return Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName;
  }

  static string[] GetTextFiles(string folderPath)
  {
    return Directory.GetFiles(folderPath, "*.txt");
  }

  static string CorrectMistakes(string text)
  {
    Dictionary<string, string> mistakeDic = new Dictionary<string, string>()
        {
            { "првиет", "привет" },
            { "пирвет", "привет" },
            { "здравсвуйте", "здравствуйте" },
            { "спосибо", "спасибо" }
        };

    foreach (var mistake in mistakeDic)
    {
      text = text.Replace(mistake.Key, mistake.Value);
    }

    return text;
  }

  static string FixPhoneNumbers(string text)
  {
    string pattern = @"\((\d{3})\)\s(\d{3})-(\d{2})-(\d{2})";
    return Regex.Replace(text, pattern, FormatPhoneNumber);
  }

  static string FormatPhoneNumber(Match match)
  {
    string code = match.Groups[1].Value;
    string part1 = match.Groups[2].Value;
    string part2 = match.Groups[3].Value;
    string part3 = match.Groups[4].Value;

    return $"+380 {code.Substring(1)} {part1} {part2} {part3}";
  }
}