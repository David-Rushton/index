using System.ComponentModel;
using Spectre.Console.Cli;

namespace Dr.Index.Commands;

public abstract class SettingsBase : CommandSettings
{
    [Description("Enables verbose exception reports")]
    [CommandOption("--verbose")]
    public bool IsVerboseMode { get; set; }
}
