bool IsEmptyTime(string? time) => string.IsNullOrWhiteSpace(time);

void Start(int timeInSeconds)
{
  int currentTime = 0;

  while (currentTime < timeInSeconds)
  {
    Console.Clear();
    currentTime++;
    Console.WriteLine(currentTime);
    Thread.Sleep(1000);
  }
}

string ShowMenu()
{
  Console.WriteLine("**** Menu ****");
  Console.WriteLine("S = Segundo");
  Console.WriteLine("M = Minutos");
  Console.WriteLine("1 = Sair");
  Console.Write("Quando tempo deseja contar?: ");

  string? response = Console.ReadLine()?.ToLower();
  if (IsEmptyTime(response))
    throw new Exception("Por favor informe um valor.");

  return response!;
}

void Main()
{
  while (true)
  {
    Console.Clear();

    string response = ShowMenu();

    if (response.Equals("1"))
      Environment.Exit(0);

    char counterType = char.Parse(response!.Substring(response.Length - 1, 1));
    int time = int.Parse(response!.Remove(response.Length - 1, 1));

    switch (counterType)
    {
      case 's':
        Start(time);
        break;
      case 'm':
        int timeInSeconds = time * 60;
        Start(timeInSeconds);
        break;
      default:
        Console.WriteLine("Opção de tempo inválida.");
        break;
    }

    Console.WriteLine("Cronômetro finalizado. Retornando para o menu...");
    Thread.Sleep(2500);
  }
}

Main();