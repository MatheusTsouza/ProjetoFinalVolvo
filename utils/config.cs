using System;
using System.IO;

namespace ProjetoFinalVolvo
{
  class config
  {
    public string linhaConfiguracao(string localArquivo, int numeroLinha)
    {
      string[] linhas = File.ReadAllLines(localArquivo);
      int contador = 1;
      string comando = "";
      foreach (var linha in linhas)
      {
        if (contador == numeroLinha)
        {
          comando = linha;
        }
        contador += 1;
      }
      return comando;
    }
  }
}