namespace Decorator.Exemplo.OO
{
    public class DescontoPlanoSaudeCalculadoraSalario : DecoratorCalculadoraSalario
    {
        public DescontoPlanoSaudeCalculadoraSalario(ICalculadoraSalario calculadoraBase) : 
            base(calculadoraBase)
        {}

        protected override double AplicarTransformacao(double salarioBase)
        => salarioBase - 600;
    }
}
