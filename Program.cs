using ConsoleUserInterfaceConstructionKit;
using ConsoleUserInterfaceConstructionKit.MenuOptions;
using ConsoleUserInterfaceConstructionKit.Menus;

var mainMenu = new DefaultMenu("Main Menu");
var settingsMenu = new DefaultMenu("Settings Menu");
var menuManager = new MenuManager();
var volume = 50;

mainMenu.AddOption(new ActionMenuOption("Start Game", () => Console.WriteLine("Game started")));
mainMenu.AddOption(new ActionMenuOption("Settings", () => menuManager.NavigateTo(settingsMenu)));
mainMenu.AddOption(new ActionMenuOption("Exit", () => Environment.Exit(0)));

settingsMenu.AddOption(new IntMenuOption("Volume", volume, updateAction: value => { volume = value; }, 0, 100));
settingsMenu.AddOption(new ActionMenuOption("Back", () => menuManager.NavigateBack()));

menuManager.NavigateTo(mainMenu);
menuManager.Run();