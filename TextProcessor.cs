using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TextProcessor
{
  private Dictionary<string, string> mistakeDictionary = new Dictionary<string, string>()
    {
        { "првиет", "привет" },
        { "пирвет", "привет" },
        { "здравсвуйте", "здравствуйте" },
        { "спосибо", "спасибо" }
    };

  private string phonePattern = @"\((\d{3})\)\s(\d{3})-(\d{2})-(\d{2})";

  public string CorrectMistakes(string text)
  {
    foreach (var mistake in mistakeDictionary)
    {
      text = text.Replace(mistake.Key, mistake.Value);
    }

    return text;
  }

  public string FixPhoneNumbers(string text)
  {
    return Regex.Replace(text, phonePattern, FormatPhoneNumber);
  }

  private string FormatPhoneNumber(Match match)
  {
    string code = match.Groups[1].Value;
    string part1 = match.Groups[2].Value;
    string part2 = match.Groups[3].Value;
    string part3 = match.Groups[4].Value;

    return $"+380 {code.Substring(1)} {part1} {part2} {part3}";
  }
}