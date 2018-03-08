using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Exemplo.FP
{
    public static class ComandosSalvar
    {
        public static void SalvarRegistro(long codigo)
            => Console.WriteLine($"Registro salvo: {codigo}");

    }
}
