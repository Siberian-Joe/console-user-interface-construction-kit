using ConsoleUserInterfaceConstructionKit.Core;
using ConsoleUserInterfaceConstructionKit.Core.Abstracts;

namespace ConsoleUserInterfaceConstructionKit.MenuOptions;

public class ToggleOption : MenuOptionBase
{
    private readonly Bindable<bool>? _bindable;
    private readonly Func<bool>? _stateGetter;
    private readonly Action<bool>? _stateSetter;

    public ToggleOption(string name, Bindable<bool> bindable) 
        : base(name)
    {
        _bindable = bindable;
    }

    public ToggleOption(string name, Func<bool> stateGetter, Action<bool> stateSetter) 
        : base(name)
    {
        _stateGetter = stateGetter;
        _stateSetter = stateSetter;
    }

    public override void Execute()
    {
        if (_bindable != null)
        {
            _bindable.Value = !_bindable.Value;
        }
        else if (_stateGetter != null && _stateSetter != null)
        {
            var newState = !_stateGetter();
            _stateSetter(newState);
        }
    }

    public override void Render()
    {
        var state = _bindable?.Value ?? _stateGetter?.Invoke() ?? false;
        Console.WriteLine($"{Name}: {(state ? "On" : "Off")}");
    }
}