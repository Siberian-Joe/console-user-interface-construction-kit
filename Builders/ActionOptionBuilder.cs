using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.MenuOptions;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class ActionOptionBuilder : IOptionBuilder
{
    private string _title = string.Empty;
    private Action? _action;

    public ActionOptionBuilder Title(string title)
    {
        _title = title;
        return this;
    }

    public ActionOptionBuilder Do(Action action)
    {
        _action = action;
        return this;
    }

    public IMenuOption Build() => new ActionOption(_title, _action!);
}