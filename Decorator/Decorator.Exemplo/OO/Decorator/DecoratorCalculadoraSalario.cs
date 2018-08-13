using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Exemplo.OO
{
    public abstract class DecoratorCalculadoraSalario : ICalculadoraSalario
    {
        private readonly ICalculadoraSalario _calculadoraBase;

        protected abstract double AplicarTransformacao(double salarioBase);

        public DecoratorCalculadoraSalario(ICalculadoraSalario calculadoraBase)
        {
            _calculadoraBase = calculadoraBase;
        }

        public double CalcularSalario(double valorPorHora)
        => AplicarTransformacao(
            _calculadoraBase.CalcularSalario(valorPorHora)
           );
    }
}
