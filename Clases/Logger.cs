using System;
using System.IO;

namespace Calendario.Clases
{
    public class Logger
    {
        private string ficheroLog;

        public Logger(string ficheroLog)
        {
            this.ficheroLog = ficheroLog;
        }

        public void WriteLog(string texto)
        {
            StreamWriter sw = new StreamWriter(ficheroLog);
            sw.Write(DateTime.Now.ToString("dd/MM/yyyy"));
            sw.Write(" - ");
            sw.Write(texto);
            sw.Write(DateTime.Now.ToString("HH:mm:ss"));
            sw.WriteLine(texto);
            sw.Close();
        }

    }
}
