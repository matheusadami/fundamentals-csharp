bool IsValidValue(string? value) => !string.IsNullOrWhiteSpace(value);

float Sum(float valueOne, float valueTwo) => valueOne + valueTwo;
float Sub(float valueOne, float valueTwo) => valueOne - valueTwo;
float Mul(float valueOne, float valueTwo) => valueOne * valueTwo;
float Div(float valueOne, float valueTwo)
{
  if (valueTwo <= 0)
    throw new Exception($"O número {valueOne} não pode ser dividido por zero (0).");

  return valueOne / valueTwo;
}

int ShowMenu()
{
  int response;

  Console.WriteLine("Informe o número da operação aritmética:");
  Console.WriteLine("1 - Soma");
  Console.WriteLine("2 - Substração");
  Console.WriteLine("3 - Multiplicação");
  Console.WriteLine("4 - Divisão");
  Console.WriteLine("5 - Sair");

  Console.Write("Selecione uma opção: ");
  int.TryParse(Console.ReadLine(), out response);

  return response;
}

float ReadValue(string message)
{
  Console.Write(message);
  string? readValue = Console.ReadLine();

  if (IsValidValue(readValue))
    return float.Parse(readValue!);

  throw new Exception("O número informado é inválido.");
}

void Main()
{
  while (true)
  {
    try
    {
      Console.Clear();

      int response = ShowMenu();

      if (response.Equals(5))
        Environment.Exit(0);

      float valueOne = ReadValue("Informe o 1º valor: ");
      float valueTwo = ReadValue("Informe o 2º valor: ");

      float result = 0;

      switch (response)
      {
        case 1:
          result = Sum(valueOne, valueTwo);
          break;
        case 2:
          result = Sub(valueOne, valueTwo);
          break;
        case 3:
          result = Mul(valueOne, valueTwo);
          break;
        case 4:
          result = Div(valueOne, valueTwo);
          break;
        default:
          Console.WriteLine("Opção inválida.");
          break;
      }

      Console.WriteLine($"O resultado da operação é: {result.ToString()}");
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
    finally
    {
      Console.ReadKey();
    }
  }
}

Main();