using ConsoleUserInterfaceConstructionKit.MenuOptions.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.Menus.Interfaces;

public interface IMenu
{
    string Title { get; }
    void AddOption(IMenuOption option);
    void RemoveOption(IMenuOption option);
    void Render();
    void HandleInput(ConsoleKey key);
}