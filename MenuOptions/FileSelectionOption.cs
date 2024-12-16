using ConsoleUserInterfaceConstructionKit.Core.Abstracts;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Utilities;
using ConsoleUserInterfaceConstructionKit.Menus;

namespace ConsoleUserInterfaceConstructionKit.MenuOptions;

public class FileSelectionOption(
    string name,
    IMenuNavigator navigator,
    Bindable<string> bindable,
    string? initialDirectory = null)
    : MenuOptionBase(name)
{
    private const string DefaultDisplayValue = "Not Selected";

    public override void Execute()
    {
        var fileMenu = new FileSelectionMenu(Name, navigator, file => { bindable.Value = file; }, initialDirectory);

        navigator.NavigateTo(fileMenu);
    }

    public override void Render()
    {
        var displayValue = string.IsNullOrWhiteSpace(bindable.Value)
            ? DefaultDisplayValue
            : Path.GetFileName(bindable.Value);
        Console.WriteLine($"{Name}: {displayValue}");
    }
}