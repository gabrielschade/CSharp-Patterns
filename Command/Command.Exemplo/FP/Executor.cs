using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Exemplo.FP
{
    public class Executor
    {
        public static void Executar(IEnumerable<Action> comandos)
        {
            foreach (Action comando in comandos)
                comando();
        }
    }
}
