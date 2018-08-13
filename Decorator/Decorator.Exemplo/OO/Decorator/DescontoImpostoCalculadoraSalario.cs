namespace Decorator.Exemplo.OO
{
    public class DescontoImpostoCalculadoraSalario : DecoratorCalculadoraSalario
    {
        public DescontoImpostoCalculadoraSalario(ICalculadoraSalario calculadoraBase) : 
            base(calculadoraBase)
        {}

        protected override double AplicarTransformacao(double salarioBase)
        => salarioBase - (salarioBase * 0.15);
    }
}
