public class StartGameCommand : ICommand
{
    private ScreenDirector screenDirector;

    private ScreenID previousScreen;

    private CMD id = CMD.StartGame;

    private PlayerController playerController;

    public CMD Command()
    {
        return id;
    }

    public StartGameCommand(ScreenDirector screenDirector, PlayerController playerController)
    {
        this.screenDirector = screenDirector;
        this.playerController = playerController;
    }

    public void Execute() 
    {
        previousScreen = screenDirector.currentScreen;
        screenDirector.HideScreen(previousScreen);
        screenDirector.ShowScreen(ScreenID.Tutorial);
        screenDirector.ShowScreen(ScreenID.StartConversation);

        playerController.isActive = true;
    }
    public void Unexecute()
    {
        screenDirector.HideScreen(ScreenID.Tutorial);
        screenDirector.ShowScreen(previousScreen);
        screenDirector.HideScreen(ScreenID.StartConversation);

        playerController.isActive = false;
    }
}