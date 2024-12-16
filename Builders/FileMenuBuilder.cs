using ConsoleUserInterfaceConstructionKit.Builders.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Utilities;
using ConsoleUserInterfaceConstructionKit.MenuOptions;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class FileMenuBuilder : IOptionBuilder
{
    private readonly Required<string> _title = new();
    private readonly Required<IMenuNavigator> _navigator = new();

    private string? _initialDirectory;
    private Bindable<string>? _bindablePath;

    public FileMenuBuilder Title(string title)
    {
        _title.Value = title;
        return this;
    }

    public FileMenuBuilder Navigator(IMenuNavigator navigator)
    {
        _navigator.Value = navigator;
        return this;
    }

    public FileMenuBuilder InitialDirectory(string directory)
    {
        _initialDirectory = directory;
        return this;
    }

    public FileMenuBuilder BindTo(Bindable<string> bindablePath)
    {
        _bindablePath = bindablePath;
        return this;
    }

    public IMenuOption Build() =>
        new FileSelectionOption(_title.Value, _navigator.Value, _bindablePath!, _initialDirectory);
}