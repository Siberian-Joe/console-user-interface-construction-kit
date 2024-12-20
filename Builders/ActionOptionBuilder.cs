﻿using ConsoleUserInterfaceConstructionKit.Builders.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Interfaces;
using ConsoleUserInterfaceConstructionKit.Core.Utilities;
using ConsoleUserInterfaceConstructionKit.MenuOptions;

namespace ConsoleUserInterfaceConstructionKit.Builders;

public class ActionOptionBuilder : IOptionBuilder
{
    private readonly Required<string> _title = new();

    private Action? _action;

    public ActionOptionBuilder Title(string title)
    {
        _title.Value = title;
        return this;
    }

    public ActionOptionBuilder Do(Action action)
    {
        _action = action;
        return this;
    }

    public IMenuOption Build() => new ActionOption(_title.Value, _action!);
}