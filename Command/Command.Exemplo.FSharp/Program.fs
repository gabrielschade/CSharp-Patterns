open System
open Comandos
open Comandos.ComandosLog
open Comandos.ComandosSalvar

[<EntryPoint>]
let main argv =
    [
        fun () -> logPorMensagem "Log realizado"
        fun () -> logPorEmail "Log realizado"
        fun () -> salvarRegistro 1
        fun () -> salvarRegistro 3
    ]
    |> executarComandos

    Console.ReadKey() 
    |> ignore
    0 // return an integer exit code
