namespace FSharpCommandLineTemplate

module Argument = 

    open Argu
    open System

    type CliArguments =
        | [<Unique>] Config of path:string
        | Version
        | Usage

        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | Config _ -> "specify a yaml config."
                | Version -> "Version of application"
                | Usage _ -> "print usage."


    let errorHandler =
        ProcessExiter
            (colorizer =
                function
                | ErrorCode.HelpText -> None
                | _ -> Some ConsoleColor.Red)

    let usage (parser: ArgumentParser) = printfn "%s" <| parser.PrintUsage()

    let parser =
        ArgumentParser.Create<CliArguments>(programName = "Program", errorHandler = errorHandler)
            