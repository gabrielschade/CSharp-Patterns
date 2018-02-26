using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Publish.Subscribe.Exemplo
{
    public static class CanalPublicacao
    {
        public static void PublicarEvento<T>(TipoEvento tipo, T parametros)
            where T : IEventoParametros
        {
            if (!CanalInscricao.EventosEAcoes.ContainsKey(tipo)) return;

            List<Action<IEventoParametros>> acoes =
                CanalInscricao.EventosEAcoes[tipo];

            Parallel.ForEach(acoes, acao => acao(parametros));
            //foreach (var acao in acoes)
            //    acao(parametros);
        }
    }
}
