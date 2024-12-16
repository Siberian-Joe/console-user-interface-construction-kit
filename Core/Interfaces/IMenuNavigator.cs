namespace ConsoleUserInterfaceConstructionKit.Core.Interfaces;

public interface IMenuNavigator
{
    void NavigateTo(IMenu menu);
    void NavigateBack();
    void Run();
}