using HTMLEditor;

void Main()
{
  try
  {
    Menu.Show();
  }
  catch (Exception e)
  {
    Console.WriteLine(e.Message);
  }
  finally
  {
    Console.ReadKey();
    Main();
  }
}

Main();