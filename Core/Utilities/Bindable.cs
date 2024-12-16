namespace ConsoleUserInterfaceConstructionKit.Core.Utilities;

public class Bindable<T>(T initialValue)
{
    public T Value { get; set; } = initialValue;
}