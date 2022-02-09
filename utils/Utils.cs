using System;
using System.IO;

namespace ProjetoFinalVolvo
{

  class Utils
  {

    public static bool addLog(string mensagem)
    {

      string arquivoLog = @"loggers/logErros.log";
      try
      {

        if (!File.Exists(arquivoLog))
        {
          File.Create(arquivoLog);
        }

        System.DateTime horario = System.DateTime.UtcNow;
        mensagem = horario.ToString() + ": " + mensagem + "\n";
        File.AppendAllText(arquivoLog, mensagem);
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine("Erro ao adicionar log " + arquivoLog);
        Console.WriteLine(e.Message);
        return false;
      }
    }


    public List<string> lerLog(int maxLinhas)
    {

      try
      {

        string[] logs = File.ReadAllLines(@"ets.txt");
        int contador = 1;
        List<string> ultimosLogs = new List<string>();


        foreach (var log in logs)
        {
          if (contador <= maxLinhas)
          {
            ultimosLogs.Add(log);
          }
          contador++;
        }

        return ultimosLogs;

      }
      catch (Exception e)
      {
        List<string> erro = new List<string>();
        Console.WriteLine("Erro ao ler o arquivo log");
        Console.WriteLine(e);
        erro.Append(e.Message);
        return erro;
      }
    }



  }
}