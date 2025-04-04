using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
  static void Main(string[] args)
  {
    Dictionary<string, string> mistakeDic = new Dictionary<string, string>()
    {
      { "првиет", "привет" },
      { "пирвет", "привет" },
      { "здравсвуйте", "здравствуйте" }
    };


    string inputText = "(097) 123-45-67";

    // Регулярное выражения для номеров
    string pattern = @"\((\d{3})\)\s(\d{3})-(\d{2})-(\d{2})";
    string replacement = "+380 $1 $2 $3 $4";

    string result = Regex.Replace(inputText, pattern, replacement);
  }



}