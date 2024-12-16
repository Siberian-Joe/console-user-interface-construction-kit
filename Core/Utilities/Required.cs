namespace ConsoleUserInterfaceConstructionKit.Core.Utilities;

public class Required<T>
{
    private T? _value;

    public T Value
    {
        get => _value ?? throw new InvalidOperationException($"{typeof(T).Name} is required but has not been set.");
        set => _value = value;
    }
}