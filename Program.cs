using ConsoleUserInterfaceConstructionKit.Builders;
using ConsoleUserInterfaceConstructionKit.Core;
using ConsoleUserInterfaceConstructionKit.Navigation;

var menuNavigator = new MenuNavigator();
var menuBuilder = new MenuBuilder(menuNavigator);

var volume = new Bindable<int>(50);

var mainMenu = menuBuilder
    .SetTitle("Main Menu")
    .AddOption("Start Game", () => Console.WriteLine("Game started"))
    .AddSubmenu("Settings", settingsBuilder =>
    {
        settingsBuilder
            .SetTitle("Settings Menu")
            .AddToggleOption("Mute", () => volume.Value == 0, isMuted => volume.Value = isMuted ? 0 : 50)
            .AddIntOption("Volume", volume, 0, 100)
            .AddOption("Back", () => menuNavigator.NavigateBack());
    })
    .AddOption("Exit", () => Environment.Exit(0))
    .Build();

menuNavigator.NavigateTo(mainMenu);
menuNavigator.Run();