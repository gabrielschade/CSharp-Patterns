using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Exemplo.OO
{
    public class CalculadoraSalario : ICalculadoraSalario
    {
        public double CalcularSalario(double valorPorHora)
         => valorPorHora * 40 * 5;
    }
}
