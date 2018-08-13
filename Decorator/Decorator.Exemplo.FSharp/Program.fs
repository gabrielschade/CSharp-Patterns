open CalculosSalario
open System

[<EntryPoint>]
let main argv =
    let calculo =
        calcularSalarioMensal
        >> descontarImpostos
        >> descontarPlanoSaude
    
    calculo 40.0
    |> Console.WriteLine

    Console.ReadKey()
    |> ignore

    0
