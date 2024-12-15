using ConsoleUserInterfaceConstructionKit.Core.Abstracts;

namespace ConsoleUserInterfaceConstructionKit.MenuOptions;

public class ActionOption(string name, Action action) : MenuOptionBase(name)
{
    public override void Execute() => action();
}