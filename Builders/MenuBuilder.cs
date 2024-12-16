using ConsoleUserInterfaceConstructionKit.Builders.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Utilities;
using ConsoleUserInterfaceConstructionKit.MenuOptions;
using ConsoleUserInterfaceConstructionKit.Menus;
using ConsoleUserInterfaceConstructionKit.Navigation;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class MenuBuilder(MenuNavigator navigator) : IMenuBuilder
{
    private readonly List<IMenuOption> _options = new();
    private readonly Required<string> _title = new();

    public IMenuBuilder Title(string title)
    {
        _title.Value = title;
        return this;
    }

    public IMenuBuilder Add<T>(Action<T> configure) where T : IOptionBuilder, new()
    {
        var builder = new T();

        configure(builder);
        _options.Add(builder.Build());

        return this;
    }

    public IMenuBuilder AddSubmenu(string title, Action<IMenuBuilder> configureSubmenu)
    {
        var submenuBuilder = new MenuBuilder(navigator);

        configureSubmenu(submenuBuilder);

        var submenu = submenuBuilder.Build();

        _options.Add(new ActionOption(title, () => navigator.NavigateTo(submenu)));

        return this;
    }


    public IMenu Build()
    {
        var menu = new StandardMenu(_title.Value);

        foreach (var option in _options)
            menu.AddOption(option);

        return menu;
    }
}