module Main =

    open System
    open Argu
    module Argument = FSharpCommandLineTemplate.Argument
    module Config =  FSharpCommandLineTemplate.Config

    let exit code = code

    let die (ex: Exception) =
        printfn $"Exiting caught: %s{ex.Message}"
        exit -1

    let printVersion () =
        let version = "v0.1"
        printfn $"%A{version}"

    let printConfig (path:string) =
        let text = Config.load path
        printfn $"Text = {text.Foo.Text}"

    [<EntryPoint>]
    let main (argv: string array) =

        try
            let results = Argument.parser.Parse argv

            if results.Contains Argument.Version then printVersion ()
            elif results.Contains Argument.Config then printConfig (results.GetResult Argument.Config)
            else Argument.usage Argument.parser

            exit 0
        with
        | :? ArguParseException as ex ->
            Argument.usage Argument.parser
            die ex
        | ex -> die ex