using System;

namespace Publish.Subscribe.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            CanalInscricao.RegistrarInscricao<EventoRegistroMensagemParametros>(
                TipoEvento.RegistroDeMensagem,
                Eventos.RegistrarMensagem);

            CanalInscricao.RegistrarInscricao<EventoRegistroMensagemParametros>(
                TipoEvento.RegistroDeMensagem,
                Eventos.MensagemEmMaisculo);

            Escrever("Hello World!");
            Console.ReadKey();
        }

        static void Escrever(string mensagem)
        {
            CanalPublicacao.PublicarEvento(
                TipoEvento.RegistroDeMensagem,
                new EventoRegistroMensagemParametros() { Mensagem = mensagem });

            Console.WriteLine(mensagem);
        }
    }
}
