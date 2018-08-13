using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator.Exemplo.FP
{
    public class CalculadoraSalarioFP
    {
        public double Valor { get; private set; }

        public CalculadoraSalarioFP(double valorPorHora)
        {
            Valor = valorPorHora;
        }

        public CalculadoraSalarioFP Calcular(Func<double,double> calculo)
        {
            Valor = calculo(Valor);
            return this;
        }
    }
}
