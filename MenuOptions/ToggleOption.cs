using ConsoleUserInterfaceConstructionKit.Core.Abstracts;
using ConsoleUserInterfaceConstructionKit.Core.Utilities;

namespace ConsoleUserInterfaceConstructionKit.MenuOptions;

public class ToggleOption(
    string name,
    Bindable<bool>? bindable = null,
    Func<bool>? stateGetter = null,
    Action<bool>? stateSetter = null)
    : MenuOptionBase(name)
{
    public override void Execute()
    {
        if (bindable != null)
        {
            bindable.Value = !bindable.Value;
        }
        else if (stateGetter != null && stateSetter != null)
        {
            var newState = !stateGetter();
            stateSetter(newState);
        }
    }

    public override void Render()
    {
        var state = bindable?.Value ?? stateGetter?.Invoke() ?? false;
        Console.WriteLine($"{Name}: {(state ? "On" : "Off")}");
    }
}