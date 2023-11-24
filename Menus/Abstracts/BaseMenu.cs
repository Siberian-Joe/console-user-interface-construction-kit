using ConsoleUserInterfaceConstructionKit.MenuOptions.Interfaces;
using ConsoleUserInterfaceConstructionKit.Menus.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.Menus.Abstracts;

public abstract class BaseMenu(string title) : IMenu
{
    public string Title { get; protected set; } = title;

    protected List<IMenuOption> Options = new();
    protected int SelectedIndex;
    protected int TopVisibleIndex;
    protected int VisibleItemsCount;

    public void AddOption(IMenuOption option)
    {
        Options.Add(option);
    }

    public void RemoveOption(IMenuOption option)
    {
        Options.Remove(option);
    }

    public virtual void Render()
    {
        VisibleItemsCount = Console.WindowHeight - 4;
        var itemsToRender = Math.Min(Options.Count - TopVisibleIndex, VisibleItemsCount);

        Console.Clear();
        Console.WriteLine(Title);

        if (TopVisibleIndex > 0)
            Console.WriteLine("[More above]");

        for (var i = 0; i < itemsToRender; i++)
        {
            if (TopVisibleIndex + i == SelectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Options[TopVisibleIndex + i].Render();
            Console.ResetColor();
        }

        if (TopVisibleIndex + itemsToRender < Options.Count)
            Console.WriteLine("[More below]");
    }

    public virtual void HandleInput(ConsoleKey key)
    {
        var previousIndex = SelectedIndex;

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
        }

        AdjustVisibleItems();

        if (previousIndex != SelectedIndex)
        {
            Render();
        }
    }

    protected void AdjustVisibleItems()
    {
        if (SelectedIndex < TopVisibleIndex)
        {
            TopVisibleIndex = SelectedIndex;
        }
        else if (SelectedIndex >= TopVisibleIndex + VisibleItemsCount)
        {
            TopVisibleIndex = SelectedIndex - VisibleItemsCount + 1;
        }
    }
}