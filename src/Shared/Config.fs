namespace FSharpCommandLineTemplate

module Config = 
    open System
    open FSharp.Configuration
    open System.IO

    [<Literal>]
    let templatePath = "data/TemplateConfig.yaml" 
    
    [<Literal>]
    let resolutionPath = "temp"

    
    type Config = YamlConfig<templatePath>

    let load (path:string) =
        
        let config = Config()

        config.Load path

        config
