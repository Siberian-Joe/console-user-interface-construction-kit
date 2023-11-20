using ConsoleUserInterfaceConstructionKit.Menus.Interfaces;

namespace ConsoleUserInterfaceConstructionKit;

public class MenuManager
{
    private readonly Stack<IMenu> _menuStack = new();

    public void NavigateTo(IMenu menu)
    {
        _menuStack.Push(menu);
    }

    public void NavigateBack()
    {
        if (_menuStack.Count > 1)
            _menuStack.Pop();
    }

    public void Run()
    {
        while (_menuStack.Any())
        {
            var currentMenu = _menuStack.Peek();
            currentMenu.Render();
            var key = Console.ReadKey().Key;
            currentMenu.HandleInput(key);
        }
    }
}