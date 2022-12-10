// See https://aka.ms/new-console-template for more information

using CsTsTranslator;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;

if (args.Length < 2)
{
    Console.WriteLine(GetHelpMessage());
    return;
}

var configFile = args[0];
if(!File.Exists($"{configFile}"))
{
    Console.WriteLine($"File {configFile} does not exist");
    return;
}

var configFileContent = File.ReadAllText(configFile);
var config = JsonConvert.DeserializeObject<Config>(configFileContent);

foreach (var arg in args.Skip(1))
{
    if(arg is "-r")
    {
        var routesTranslator = new RoutesTranslator();

        var csContent = File.ReadAllText(config!.Routes.CsFile);
        var tsContent = routesTranslator.Translate(csContent);

        File.WriteAllText(config.Routes.TargetTsFile, tsContent);

        Console.WriteLine("Routes file was successfully translated!");

        continue;
    }
}

static string GetHelpMessage()
{
    string name = Assembly.GetExecutingAssembly().GetName().Name!;

    var msg = $"""
        
        Usage: {name}.exe config_file [-r] [-m]

        Options: 
            -r      Translate C# routes static class into TypeScript.
            -m      Transalte C# models into TypeScript
        """;

    return msg;
}