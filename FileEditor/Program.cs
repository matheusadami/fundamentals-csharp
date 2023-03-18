string DEFAULT_FILES_DIRECTORY_PATH = $"{Directory.GetCurrentDirectory()}\\Files";

void SaveFile(string fileContent)
{
  Console.Write("Digite o nome do arquivo: ");
  string? fileName = Console.ReadLine();

  if (string.IsNullOrWhiteSpace(fileName))
    throw new Exception("Nome do arquivo inválido.");

  if (!Directory.Exists(DEFAULT_FILES_DIRECTORY_PATH))
    Directory.CreateDirectory(DEFAULT_FILES_DIRECTORY_PATH);

  string filePath = $"{DEFAULT_FILES_DIRECTORY_PATH}\\{fileName}";
  using (var file = new StreamWriter(filePath))
  {
    file.Write(fileContent);
  }

  Console.WriteLine("Arquivo salvo com sucesso.");
}

void OpenFile()
{
  Console.Clear();

  Console.Write("Informe o nome do arquivo que deseja abrir: ");
  string? fileName = Console.ReadLine();

  if (string.IsNullOrWhiteSpace(fileName))
    throw new Exception("Por favor informe o nome do arquivo.");

  string filePath = $"{DEFAULT_FILES_DIRECTORY_PATH}\\{fileName}";
  using (var file = new StreamReader(filePath))
  {
    string fileContent = file.ReadToEnd();
    Console.WriteLine(fileContent);
  }
}

void UpdateFile()
{
  string fileContent = string.Empty;

  Console.Clear();
  Console.WriteLine("Digite seu texto abaixo: (ESC para sair)");
  Console.WriteLine("------------------------");

  do
  {
    // Read the text line has wrote by user
    fileContent += Console.ReadLine();
    // Add a new line break (\n) when user types "Enter"
    fileContent += Environment.NewLine;
  }
  // If the key is different to "ESC", so the program continues reading the file content. 
  while (Console.ReadKey().Key != ConsoleKey.Escape);

  Console.WriteLine("------------------------");
  SaveFile(fileContent);
}

byte ShowMenu()
{
  Console.WriteLine("**** Menu ****");
  Console.WriteLine("Selecione uma opção abaixo:");
  Console.WriteLine("1 - Abrir arquivo");
  Console.WriteLine("2 - Criar/Editar arquivo");
  Console.WriteLine("3 - Sair");
  Console.Write("Opção selecionada: ");
  string? response = Console.ReadLine();

  if (string.IsNullOrWhiteSpace(response))
    throw new Exception("Por favor informe uma opção.");

  return byte.Parse(response);
}

void Main()
{
  while (true)
  {
    try
    {
      Console.Clear();

      byte response = ShowMenu();

      switch (response)
      {
        case 1:
          OpenFile();
          break;
        case 2:
          UpdateFile();
          break;
        case 3:
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Opção inválida.");
          break;
      }
    }
    catch (System.Exception e)
    {
      Console.WriteLine($"Erro na execução do programa: {e.Message}");
    }
    finally
    {
      Console.ReadKey();
      Main();
    }
  }
}

Main();