using Spectre.Console.Cli;

namespace Dr.Index.Commands;

/// <summary>
/// A card is the top level item in the index.
/// </summary>
public class NewCardCommand : AsyncCommand<NewCardCommand.Settings>
{
    public class Settings : SettingsBase
    {

    }

    public override Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        throw new NotImplementedException();
    }
}
