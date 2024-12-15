using ConsoleUserInterfaceConstructionKit.Core;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public interface IMenuBuilder
{
    IMenuBuilder SetTitle(string title);
    IMenuBuilder AddOption(string name, Action action);
    IMenuBuilder AddIntOption(string name, Bindable<int> bindable, int? minValue = null, int? maxValue = null);
    IMenuBuilder AddToggleOption(string name, Bindable<bool> bindable);
    IMenuBuilder AddToggleOption(string name, Func<bool> stateGetter, Action<bool> stateSetter);
    IMenuBuilder AddSubmenu(string name, Action<IMenuBuilder> submenuBuilder);
    IMenu Build();
}