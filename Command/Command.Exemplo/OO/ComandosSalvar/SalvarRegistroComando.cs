using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Exemplo.OO.ComandosSalvar
{
    public class SalvarRegistroComando :  IComando
    {
        private readonly long _codigo;

        public SalvarRegistroComando(long codigo)
        {
            _codigo = codigo;
        }

        public void Executar()
        {
            Console.WriteLine($"Registro salvo: {_codigo}");
        }
    }
}
