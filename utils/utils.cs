using System;
using System.IO;

namespace ProjetoFinalVolvo {

    class Utils {

        public static bool addLog(string mensagem) {

            string arquivoLog = @"loggers/logErros.log";
            try {
                System.DateTime horario = System.DateTime.UtcNow;
                mensagem = horario.ToString() + ": " + mensagem + "\n";
                File.AppendAllText(arquivoLog, mensagem);
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Erro ao adicionar log" + arquivoLog);
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public static string[] lerLog(int maxLinhas) {

            string arquivoLog = @"loggers/logErros.log";
            string[] logs = {};
            try {
                StreamReader stream = new StreamReader(arquivoLog);

                string linha;
                int i=0;
                while ( (linha = stream.ReadLine()) != null ) {
                    logs[i] = linha;
                    i++;
                }

            }
            catch (Exception e) {
                Console.WriteLine("Erro ao ler log" + arquivoLog);
                Console.WriteLine(e);
            }
            return logs;
        }



    }
}