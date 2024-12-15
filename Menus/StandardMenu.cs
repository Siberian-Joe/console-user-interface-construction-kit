using ConsoleUserInterfaceConstructionKit.Core.Abstracts;

namespace ConsoleUserInterfaceConstructionKit.Menus;

public class StandardMenu(string title) : MenuBase(title)
{
    public override void HandleInput(ConsoleKey key)
    {
        var currentIndex = SelectedIndex;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                SelectedIndex = Math.Max(0, SelectedIndex - 1);
                break;
            case ConsoleKey.DownArrow:
                SelectedIndex = Math.Min(Options.Count - 1, SelectedIndex + 1);
                break;
            case ConsoleKey.Enter:
                Options[SelectedIndex].Execute();
                break;
            case ConsoleKey.LeftArrow:
            case ConsoleKey.RightArrow:
                Options[SelectedIndex].HandleInput(key);
                break;
        }

        if (currentIndex != SelectedIndex || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
            Render();
    }
}