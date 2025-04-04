using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
  static void Main(string[] args)
  {
    Dictionary<string, string> mistakeDic = new Dictionary<string, string>()
    {
      { "првиет", "привет" },
      { "пирвет", "привет" },
      { "здравсвуйте", "здравствуйте" },
      { "спосибо", "спасибо" }
    };

    string folderPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName;
    string[] files = Directory.GetFiles(folderPath, "*.txt");

    foreach (string file in files)
    {
      string text = File.ReadAllText(file);

      foreach (var mistake in mistakeDic)
      {
        text = text.Replace(mistake.Key, mistake.Value);
      }

      string pattern = @"\((\d{3})\)\s(\d{3})-(\d{2})-(\d{2})";

      text = Regex.Replace(text, pattern, FormatPhoneNumber);

      File.WriteAllText(file, text);

      Console.WriteLine($"Исправления внесены в файл: {file}");
    }
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