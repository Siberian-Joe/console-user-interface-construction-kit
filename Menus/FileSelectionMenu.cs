using ConsoleUserInterfaceConstructionKit.Core.Abstracts;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.MenuOptions;

namespace ConsoleUserInterfaceConstructionKit.Menus;

public class FileSelectionMenu : MenuBase
{
    private readonly IMenuNavigator _navigator;
    private readonly Action<string> _fileSelected;

    private string _currentDirectory;

    public FileSelectionMenu(string title, IMenuNavigator navigator, Action<string> fileSelected,
        string? initialDirectory = null) : base(title)
    {
        _navigator = navigator;
        _fileSelected = fileSelected;
        _currentDirectory = initialDirectory ?? Directory.GetCurrentDirectory();
        UpdateMenuOptions();
    }

    private void UpdateMenuOptions()
    {
        Options.Clear();

        Console.WriteLine($"Current Directory: {_currentDirectory}\n");

        if (Directory.GetParent(_currentDirectory) != null)
        {
            AddOption(new ActionOption("[..]", () =>
            {
                _currentDirectory = Directory.GetParent(_currentDirectory)?.FullName ?? _currentDirectory;
                UpdateMenuOptions();
                Render();
            }));
        }

        var directories = Directory.GetDirectories(_currentDirectory);
        foreach (var directory in directories)
        {
            AddOption(new ActionOption($"[{Path.GetFileName(directory)}]", () =>
            {
                _currentDirectory = directory;
                UpdateMenuOptions();
                Render();
            }));
        }

        var files = Directory.GetFiles(_currentDirectory);
        foreach (var file in files)
        {
            AddOption(new ActionOption(Path.GetFileName(file), () =>
            {
                _fileSelected(file);
                _navigator.NavigateBack();
            }));
        }

        AddOption(new ActionOption("Exit File Menu", () => _navigator.NavigateBack()));
    }
}