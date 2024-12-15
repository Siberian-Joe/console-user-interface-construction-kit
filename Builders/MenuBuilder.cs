using ConsoleUserInterfaceConstructionKit.Core;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.MenuOptions;
using ConsoleUserInterfaceConstructionKit.Menus;
using ConsoleUserInterfaceConstructionKit.Navigation;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class MenuBuilder(MenuNavigator menuNavigator) : IMenuBuilder
{
    private const string DefaultMenuTitle = "Menu";


    private readonly List<IMenuOption> _options = new();

    private string _title = DefaultMenuTitle;

    public IMenuBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public IMenuBuilder AddOption(string name, Action action)
    {
        _options.Add(new ActionOption(name, action));
        return this;
    }

    public IMenuBuilder AddIntOption(string name, Bindable<int> bindable, int? minValue = null, int? maxValue = null)
    {
        _options.Add(new IntOption(name, bindable, minValue, maxValue));
        return this;
    }

    public IMenuBuilder AddToggleOption(string name, Bindable<bool> bindable)
    {
        _options.Add(new ToggleOption(name, bindable));
        return this;
    }

    public IMenuBuilder AddToggleOption(string name, Func<bool> stateGetter, Action<bool> stateSetter)
    {
        _options.Add(new ToggleOption(name, stateGetter, stateSetter));
        return this;
    }

    public IMenuBuilder AddSubmenu(string name, Action<IMenuBuilder> submenuBuilder)
    {
        var submenuBuilderInstance = new MenuBuilder(menuNavigator);
        submenuBuilder(submenuBuilderInstance);
        var submenu = submenuBuilderInstance.Build();

        _options.Add(new ActionOption(name, () => menuNavigator.NavigateTo(submenu)));
        return this;
    }

    public IMenu Build()
    {
        var menu = new StandardMenu(_title);
        foreach (var option in _options)
        {
            menu.AddOption(option);
        }

        return menu;
    }
}