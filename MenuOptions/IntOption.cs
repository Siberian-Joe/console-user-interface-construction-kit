using ConsoleUserInterfaceConstructionKit.Core;
using ConsoleUserInterfaceConstructionKit.Core.Abstracts;

namespace ConsoleUserInterfaceConstructionKit.MenuOptions;

public class IntOption(string name, Bindable<int> bindable, int? minValue = null, int? maxValue = null)
    : MenuOptionBase(name)
{
    public override void Render() => Console.WriteLine($"{Name}: {bindable.Value}");

    public override bool HandleInput(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow when minValue == null || bindable.Value > minValue:
                bindable.Value--;
                return true;

            case ConsoleKey.RightArrow when maxValue == null || bindable.Value < maxValue:
                bindable.Value++;
                return true;
        }

        return false;
    }
}