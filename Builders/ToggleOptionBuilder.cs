using ConsoleUserInterfaceConstructionKit.Builders.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Utilities;
using ConsoleUserInterfaceConstructionKit.MenuOptions;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class ToggleOptionBuilder : IOptionBuilder
{
    private readonly Required<string> _title = new();

    private Bindable<bool>? _bindable;
    private Func<bool>? _stateGetter;
    private Action<bool>? _stateSetter;

    public ToggleOptionBuilder Title(string title)
    {
        _title.Value = title;
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

    public IMenuOption Build() => new ToggleOption(_title.Value, _bindable, _stateGetter, _stateSetter);
}