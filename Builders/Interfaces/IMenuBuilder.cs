using ConsoleUserInterfaceConstructionKit.Core.Interfaces;

namespace ConsoleUserInterfaceConstructionKit.Builders.Interfaces;

public interface IMenuBuilder
{
    IMenuBuilder Title(string title);
    IMenuBuilder Add<T>(Action<T> configure) where T : IOptionBuilder, new();
    IMenuBuilder AddSubmenu(string title, Action<IMenuBuilder> configureSubmenu);
    IMenu Build();
}