using ConsoleUserInterfaceConstructionKit.Core;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.MenuOptions;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class ToggleOptionBuilder : IOptionBuilder
{
    private string _title = string.Empty;
    private Bindable<bool>? _bindable;
    private Func<bool>? _stateGetter;
    private Action<bool>? _stateSetter;

    public ToggleOptionBuilder Title(string title)
    {
        _title = title;
        return this;
    }

    public ToggleOptionBuilder Toggle(Func<bool> getter, Action<bool> setter)
    {
        _stateGetter = getter;
        _stateSetter = setter;
        return this;
    }

    public ToggleOptionBuilder BindTo(Bindable<bool> bindable)
    {
        _bindable = bindable;
        return this;
    }

    public IMenuOption Build()
    {
        return new ToggleOption(_title, _bindable, _stateGetter, _stateSetter);
    }
}
