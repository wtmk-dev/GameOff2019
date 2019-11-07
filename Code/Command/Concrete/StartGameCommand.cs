public class StartGameCommand : ICommand
{
    private ScreenDirector screenDirector;

    private ScreenID previousScreen;

    private CMD id = CMD.StartGame;

    public CMD Command()
    {
        return id;
    }

    public StartGameCommand(ScreenDirector screenDirector)
    {
        this.screenDirector = screenDirector;
    }

    public void Execute() 
    {
        previousScreen = screenDirector.currentScreen;
        screenDirector.HideScreen(previousScreen);
        screenDirector.ShowScreen(ScreenID.Tutorial);
    }
    public void Unexecute()
    {
        screenDirector.HideScreen(ScreenID.Tutorial);
        screenDirector.ShowScreen(previousScreen);
    }
}