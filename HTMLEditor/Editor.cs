using System.Text;

namespace HTMLEditor;

public static class Editor
{
  public static void Show()
  {
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.Clear();

    Console.WriteLine("**** Modo de Edição (ESC para sair) ****");
    Console.WriteLine("-------------------------------------");

    Start();
  }

  private static void Start()
  {
    var fileContent = new StringBuilder();

    do
    {
      fileContent.Append(Console.ReadLine());
      fileContent.Append(Environment.NewLine);
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Console.WriteLine("-------------------------------------");
    Console.WriteLine("Deseja salvar o arquivo?");
    Console.WriteLine("1 - Sim");
    Console.WriteLine("2 - Não");
    Console.Write("Opção selecionada: ");

    string? response = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(response))
      throw new Exception("Por favor selecione uma opção.");

    short option = short.Parse(response);
    HandleSavingOption(option, fileContent.ToString());
  }

  private static void HandleSavingOption(short option, string fileContent)
  {
    switch (option)
    {
      case 1:
        Viewer.Show(fileContent);
        break;
      case 2:
        Environment.Exit(0);
        break;
    }
  }
}