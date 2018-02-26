using System;
using System.Collections.Generic;
using System.Text;

namespace Publish.Subscribe.Exemplo
{
    public class Eventos
    {
        public static void RegistrarMensagem(EventoRegistroMensagemParametros parametros)
        {
            Console.WriteLine($"Antes da mensagem ser enviada: {parametros.Mensagem}");
        }

        public static void MensagemEmMaisculo(EventoRegistroMensagemParametros parametros)
        {
            Console.WriteLine($"Mensagem transformada: {parametros.Mensagem.ToUpper()}");
        }
    }
}
