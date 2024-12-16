using ConsoleUserInterfaceConstructionKit.Builders.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Utilities;
using ConsoleUserInterfaceConstructionKit.MenuOptions;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class IntOptionBuilder : IOptionBuilder
{
    private readonly Required<string> _title = new();

    private Bindable<int>? _bindable;
    private int? _minValue;
    private int? _maxValue;

    public IntOptionBuilder Title(string title)
    {
        _title.Value = title;
        return this;
    }

    public IntOptionBuilder BindTo(Bindable<int> bindable)
    {
        _bindable = bindable;
        return this;
    }

    public IntOptionBuilder Range(int? minValue, int? maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }

    public IMenuOption Build() => new IntOption(_title.Value, _bindable!, _minValue, _maxValue);
}