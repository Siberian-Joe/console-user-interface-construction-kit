using ConsoleUserInterfaceConstructionKit.Core.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.Core.Abstracts;

public abstract class MenuBase(string title) : IMenu
{
    public string Title { get; protected set; } = title;
    protected List<IMenuOption> Options { get; } = new();
    protected int SelectedIndex;

    private int _topVisibleIndex;

    private static int VisibleItemsCount => Console.WindowHeight - 4;

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
        Console.Clear();
        Console.WriteLine(Title);
        Console.WriteLine(new string('-', Title.Length));

        if (_topVisibleIndex > 0)
            Console.WriteLine("[More above]");

        for (var i = 0; i < Math.Min(Options.Count - _topVisibleIndex, VisibleItemsCount); i++)
        {
            if (_topVisibleIndex + i == SelectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Options[_topVisibleIndex + i].Render();
            Console.ResetColor();
        }

        if (_topVisibleIndex + VisibleItemsCount < Options.Count)
            Console.WriteLine("[More below]");
    }

    public virtual void HandleInput(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                SelectedIndex = Math.Max(0, SelectedIndex - 1);
                AdjustVisibleItems();
                break;

            case ConsoleKey.DownArrow:
                SelectedIndex = Math.Min(Options.Count - 1, SelectedIndex + 1);
                AdjustVisibleItems();
                break;

            case ConsoleKey.Enter:
                Options[SelectedIndex].Execute();
                break;

            default:
                if (Options[SelectedIndex].HandleInput(key))
                    Render();
                break;
        }
    }

    private void AdjustVisibleItems()
    {
        if (SelectedIndex < _topVisibleIndex)
            _topVisibleIndex = SelectedIndex;
        else if (SelectedIndex >= _topVisibleIndex + VisibleItemsCount)
            _topVisibleIndex = SelectedIndex - VisibleItemsCount + 1;
    }
}