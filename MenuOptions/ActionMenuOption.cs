using ConsoleUserInterfaceConstructionKit.MenuOptions.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.MenuOptions;

public class ActionMenuOption(string name, Action action) : IMenuOption
{
    public string Name { get; protected set; } = name;

    public void Execute()
    {
        action();
    }

    public void Render()
    {
        Console.WriteLine(Name);
    }

    public void HandleInput(ConsoleKey key)
    {
    }
}