using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Exemplo.FP
{
    public static class ComandosLog
    {
        public static void LogPorEmail(string mensagem)
            => Console.WriteLine($"E-mail: {mensagem}");

        public static void LogPorMensagem(string mensagem)
            => Console.WriteLine($"Log: {mensagem}");
    }
}
