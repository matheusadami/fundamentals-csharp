using System.Text.RegularExpressions;
namespace HTMLEditor;

public static class Viewer
{
  public static void Show(string fileContent)
  {
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.Clear();

    Console.WriteLine("**** Modo de Visualização ****");
    Console.WriteLine("-------------------------------------");

    Replace(fileContent);
  }

  private static void Replace(string fileContent)
  {
    // NOTE: This program gets only the first word between HTML tag <strong></strong> (yet).
    var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
    string[] words = fileContent.Split(" ");

    for (int i = 0; i < words.Length; i++)
    {
      if (strong.IsMatch(words[i]))
      {
        PrintFormattedWord(strong, words[i]);
        continue;
      }

      PrintNoFormattedWord(words[i]);
    }
  }

  private static void PrintFormattedWord(Regex regex, string word)
  {
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write($"{RemoveHTMLTagsFromString(word)} ");
  }

  private static void PrintNoFormattedWord(string word)
  {
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write($"{word} ");
  }

  private static string RemoveHTMLTagsFromString(string content)
  {
    int fromCaracter = content.IndexOf('>');
    int untilCaracter = (content.LastIndexOf('<') - 1) - fromCaracter;
    return content.Substring(++fromCaracter, untilCaracter);
  }
}
