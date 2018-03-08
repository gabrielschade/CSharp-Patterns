using System;

namespace Command.Exemplo.OO.ComandosLog
{
    public class LogEmailComando : IComando
    {
        private readonly string _mensagem;
        public LogEmailComando(string mensagem)
        {
            _mensagem = mensagem;
        }

        public void Executar()
        {
            Console.WriteLine($"E-mail: {_mensagem}");
        }
    }
}
