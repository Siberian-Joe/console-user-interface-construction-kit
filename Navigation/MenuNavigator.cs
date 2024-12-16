using ConsoleUserInterfaceConstructionKit.Core.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.Navigation;

public class MenuNavigator : IMenuNavigator
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
        Console.CursorVisible = false;

        while (_menuStack.Count != 0)
        {
            var currentMenu = _menuStack.Peek();
            currentMenu.Render();
            var key = Console.ReadKey(true).Key;
            currentMenu.HandleInput(key);
        }

        Console.CursorVisible = true;
    }
}