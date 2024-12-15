namespace ConsoleUserInterfaceConstructionKit.Core.Interfaces;

public interface IMenuOption
{
    string Name { get; }
    void Execute();
    void Render();
    bool HandleInput(ConsoleKey key);
}