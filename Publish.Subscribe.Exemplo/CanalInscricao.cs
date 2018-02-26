using System;
using System.Collections.Generic;
using System.Text;

namespace Publish.Subscribe.Exemplo
{
    public static class CanalInscricao
    {
        internal static Dictionary<TipoEvento, List<Action<IEventoParametros>>> EventosEAcoes { get; private set; }

        public static void RegistrarInscricao<T>(TipoEvento tipo, Action<T> acao)
            where T : IEventoParametros
        {
            void acaoConvertida(IEventoParametros evento) =>
                acao((T)evento);

            if (EventosEAcoes == null)
                EventosEAcoes =
                    new Dictionary<TipoEvento, List<Action<IEventoParametros>>>();

            if (!EventosEAcoes.ContainsKey(tipo))
                EventosEAcoes.Add(tipo, new List<Action<IEventoParametros>>());

            EventosEAcoes[tipo].Add(acaoConvertida);
        }
    }
}
