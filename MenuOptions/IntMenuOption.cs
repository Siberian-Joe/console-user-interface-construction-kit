using ConsoleUserInterfaceConstructionKit.MenuOptions.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.MenuOptions;

public class IntMenuOption(string name, int initialValue, Action<int> updateAction,
        int? minValue = null, int? maxValue = null)
    : IMenuOption
{
    public string Name { get; protected set; } = name;

    private int _value = initialValue < minValue ? minValue.Value :
        initialValue > maxValue ? maxValue.Value :
        initialValue;

    public void Execute()
    {
    }

    public void Render()
    {
        Console.WriteLine($"{Name}: {_value}");
    }

    public void HandleInput(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (minValue == null || _value > minValue.Value)
                {
                    _value--;
                    updateAction(_value);
                }

                break;
            case ConsoleKey.RightArrow:
                if (maxValue == null || _value < maxValue.Value)
                {
                    _value++;
                    updateAction(_value);
                }

                break;
        }
    }
}