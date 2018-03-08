using System;

namespace Command.Exemplo.OO.ComandosLog
{
    public class LogMensagemComando : IComando
    {
        private readonly string _mensagem;
        public LogMensagemComando(string mensagem)
        {
            _mensagem = mensagem;
        }

        public void Executar()
        {
            Console.WriteLine($"Log: {_mensagem}");
        }
    }
}
