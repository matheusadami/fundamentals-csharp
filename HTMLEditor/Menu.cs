using System.Drawing;

namespace HTMLEditor;

public static class Menu
{
  public static void Show()
  {
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.Clear();

    DrawScreen();
    short option = ShowOptions();
    HandleOptions(option);
  }

  private static void DrawScreen()
  {
    short amountColumns = 35;

    DrawDividerLine(amountColumns);

    for (int lines = 0; lines <= 10; lines++)
    {
      Console.Write("|");

      for (int i = 0; i <= amountColumns; i++)
        Console.Write(" ");

      Console.Write("|");
      Console.Write(Environment.NewLine);
    }

    DrawDividerLine(amountColumns);
  }

  private static void DrawDividerLine(short amountColumns)
  {
    Console.Write("+");

    for (int hyphens = 0; hyphens <= amountColumns; hyphens++)
      Console.Write("-");

    Console.Write("+");
    Console.Write(Environment.NewLine);
  }

  private static short ShowOptions()
  {
    short initialCursorColumn = 3;
    short initialCursorLine = 2;

    Console.SetCursorPosition(initialCursorColumn, initialCursorLine);
    Console.WriteLine("Editor HTML");
    Console.SetCursorPosition(initialCursorColumn, initialCursorLine += 2);
    Console.WriteLine("**** Menu ****");
    Console.SetCursorPosition(initialCursorColumn, ++initialCursorLine);
    Console.WriteLine("Selecione uma opção abaixo:");
    Console.SetCursorPosition(initialCursorColumn, ++initialCursorLine);
    Console.WriteLine("1 - Novo Arquivo");
    Console.SetCursorPosition(initialCursorColumn, ++initialCursorLine);
    Console.WriteLine("2 - Abrir Arquivo");
    Console.SetCursorPosition(initialCursorColumn, ++initialCursorLine);
    Console.WriteLine("3 - Sair");
    Console.SetCursorPosition(initialCursorColumn, ++initialCursorLine);
    Console.Write("Opção selecionada: ");

    string? response = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(response))
    {
      Console.SetCursorPosition(initialCursorColumn, ++initialCursorLine);
      throw new Exception("Por favor selecione uma opção.");
    }

    return short.Parse(response);
  }

  private static void HandleOptions(short option)
  {
    switch (option)
    {
      case 1:
        Editor.Show();
        break;
      case 2:
        // ...
        break;
      case 3:
        ExitProgram();
        break;
      default:
        ShowMenuAgain();
        break;
    }
  }

  private static void ExitProgram()
  {
    Console.Clear();
    Environment.Exit(0);
  }

  private static void ShowMenuAgain()
  {
    Console.Clear();
    Show();
  }
}
