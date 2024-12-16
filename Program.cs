using ConsoleUserInterfaceConstructionKit.Builders;
using ConsoleUserInterfaceConstructionKit.Core.Utilities;
using ConsoleUserInterfaceConstructionKit.Navigation;

var menuNavigator = new MenuNavigator();
var menuBuilder = new MenuBuilder(menuNavigator);

var volume = new Bindable<int>(50);
var path = new Bindable<string>(string.Empty);

var mainMenu = menuBuilder
    .Title("Main Menu")
    .Add<ActionOptionBuilder>(action =>
        action
            .Title("Start Game")
            .Do(() => Console.WriteLine("Game started")))
    .AddSubmenu("Settings", settingsBuilder =>
    {
        settingsBuilder
            .Title("Settings Menu")
            .Add<ToggleOptionBuilder>(toggle =>
                toggle
                    .Title("Mute")
                    .Toggle(() => volume.Value == 0, isMuted => volume.Value = isMuted ? 0 : 50))
            .Add<IntOptionBuilder>(intOption =>
                intOption
                    .Title("Volume")
                    .BindTo(volume)
                    .Range(0, 100))
            .Add<FileMenuBuilder>(fileMenu => fileMenu
                .Title("Test File")
                .Navigator(menuNavigator)
                .BindTo(path))
            .Add<ActionOptionBuilder>(action =>
                action
                    .Title("Back")
                    .Do(() => menuNavigator.NavigateBack()));
    })
    .Add<ActionOptionBuilder>(action => action
        .Title("Exit")
        .Do(() => Environment.Exit(0)))
    .Build();

menuNavigator.NavigateTo(mainMenu);
menuNavigator.Run();