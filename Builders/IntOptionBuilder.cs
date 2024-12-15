using ConsoleUserInterfaceConstructionKit.Core;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.MenuOptions;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class IntOptionBuilder : IOptionBuilder
{
    private string _title = string.Empty;
    private Bindable<int>? _bindable;
    private int? _minValue;
    private int? _maxValue;

    public IntOptionBuilder Title(string title)
    {
        _title = title;
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

    public IMenuOption Build() => new IntOption(_title, _bindable!, _minValue, _maxValue);
}