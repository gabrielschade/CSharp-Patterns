using Command.Exemplo.FP;
using Command.Exemplo.OO;
using Command.Exemplo.OO.ComandosLog;
using Command.Exemplo.OO.ComandosSalvar;
using System;
using System.Collections.Generic;

namespace Command.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            ComandosOO();
            ComandosFP();
            Console.ReadKey();
        }
        private static void ComandosFP()
        {
            List<Action> comandos = new List<Action>();
            comandos.Add( () => ComandosLog.LogPorMensagem("Log realizado"));
            comandos.Add( () => ComandosLog.LogPorEmail("Log realizado"));
            comandos.Add( () => ComandosSalvar.SalvarRegistro(1));
            comandos.Add( () => ComandosSalvar.SalvarRegistro(3));

            FP.Executor.Executar(comandos);
        }

        private static void ComandosOO()
        {
            List<IComando> comandos = new List<IComando>();

            comandos.Add(new LogMensagemComando("Log realizado"));
            comandos.Add(new LogEmailComando("Email através de comando"));
            comandos.Add(new SalvarRegistroComando(1));
            comandos.Add(new SalvarRegistroComando(3));

            OO.Executor executor = new OO.Executor();
            executor.Executar(comandos);
        }
    }
}
