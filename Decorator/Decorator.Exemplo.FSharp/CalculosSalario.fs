module CalculosSalario

let calcularSalarioMensal valorPorHora =
    valorPorHora * 40.0 * 5.0

let descontarImpostos salario =
    salario - (salario * 0.15)

let descontarPlanoSaude salario =
    salario - 600.0

