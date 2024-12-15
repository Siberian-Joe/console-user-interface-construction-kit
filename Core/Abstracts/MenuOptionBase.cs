using ConsoleUserInterfaceConstructionKit.Core.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.Core.Abstracts;

public abstract class MenuOptionBase(string name) : IMenuOption
{
    public string Name { get; protected set; } = name;

    public virtual void Execute()
    {
    }

    public virtual void Render() => Console.WriteLine(Name);

    public virtual bool HandleInput(ConsoleKey key) => false;
}