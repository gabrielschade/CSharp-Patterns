namespace Decorator.Exemplo.FP
{
    public static class CalculosSalario
    {
        public static double CalcularSalarioMensal(double valorPorHora)
            => valorPorHora * 40 * 5;

        public static double DescontarImpostos(double salario)
            => salario - (salario * 0.15);

        public static double DescontarPlanoSaude(double salario)
            => salario - 600;
    }

    
}
