using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть текст: ");
        string input = Console.ReadLine();

        string pattern = @"\{(?:[^{}]*|\{.*?\})*\}";
  
        string result = Regex.Replace(input, pattern, "{o}");

        Console.Write("Результат: ");
        Console.WriteLine(result);
    }
}
//abc
