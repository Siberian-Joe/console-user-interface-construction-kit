namespace ConsoleUserInterfaceConstructionKit.MenuOptions.Interfaces;

public interface IMenuOption
{
    string Name { get; }
    void Execute();
    void Render();
    void HandleInput(ConsoleKey key);
}