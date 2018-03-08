module Comandos

let executarComandos comandos = 
    comandos
    |> List.iter (fun comando -> comando() )

module ComandosLog =
    let logPorMensagem mensagem =
        printfn "Log: %s" mensagem

    let logPorEmail mensagem =
        printfn "E-mail: %s" mensagem


module ComandosSalvar =
    let salvarRegistro codigo =
        printfn "E-mail: %i" codigo

