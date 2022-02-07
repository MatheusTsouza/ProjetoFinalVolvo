using System;
using System.IO;
using System.Text;
using System.Net.Sockets;

namespace ProjetoFinalVolvo
{

  public class pythonToDotnet
  {
    public int Porta = 0;
    public string server = "";

    public void selecionaServidor(int porta, string server)
    {
      this.Porta = porta;
      this.server = server;
    }

    public string enviaDados(string dadosFornecidos)
    {
      byte[] dadosFonecidosByte;

      TcpClient cliente = new TcpClient(this.server, this.Porta);
      NetworkStream nwStream = cliente.GetStream();

      dadosFonecidosByte = ASCIIEncoding.ASCII.GetBytes(dadosFornecidos);
      nwStream.Write(dadosFonecidosByte, 0, dadosFonecidosByte.Length);
      string dados = recebeDados(cliente, nwStream);
      cliente.Close();

      return dados;
    }

    public string recebeDados(TcpClient cliente, NetworkStream nwStream)
    {
      int leBytes;
      string dadosRecebidos;
      byte[] bytesRecebidos = new byte[cliente.ReceiveBufferSize];
      leBytes = nwStream.Read(bytesRecebidos, 0, cliente.ReceiveBufferSize);

      dadosRecebidos = Encoding.ASCII.GetString(bytesRecebidos, 0, leBytes);

      return dadosRecebidos;

    }

  }

}