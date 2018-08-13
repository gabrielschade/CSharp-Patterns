using Decorator.Exemplo.FP;
using Decorator.Exemplo.OO;
using System;

namespace Decorator.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            DecoratorOO();
            DecoratorFP();
            Console.ReadKey();
        }

        private static void DecoratorFP()
        {
            double salarioFinal = 
                new CalculadoraSalarioFP(40)
                    .Calcular(CalculosSalario.CalcularSalarioMensal)
                    .Calcular(CalculosSalario.DescontarImpostos)
                    .Calcular(CalculosSalario.DescontarPlanoSaude)
                    .Calcular(valor => valor - (valor * 0.10))
                    .Valor;

            Console.WriteLine($"Salário com impostos e plano de saúde: {salarioFinal}");
        }

        private static void DecoratorOO()
        {
            double salarioBase = new CalculadoraSalario().CalcularSalario(40);
            Console.WriteLine($"Salário base: {salarioBase}");

            double salarioImpostos = 
                new DescontoImpostoCalculadoraSalario(
                    new CalculadoraSalario()).CalcularSalario(40);

            Console.WriteLine($"Salário com impostos: {salarioImpostos}");

            double salarioFinal = 
                new DescontoPlanoSaudeCalculadoraSalario(
                    new DescontoImpostoCalculadoraSalario(
                        new CalculadoraSalario()
                )).CalcularSalario(40);

            Console.WriteLine($"Salário com impostos e plano de saúde: {salarioFinal}");
        }
    }
}
