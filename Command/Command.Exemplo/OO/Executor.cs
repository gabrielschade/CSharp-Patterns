using System.Collections.Generic;

namespace Command.Exemplo.OO
{
    public class Executor
    {
        public void Executar(IEnumerable<IComando> comandos)
        {
            foreach (IComando comando in comandos)
                comando.Executar();
        }
    }
}
