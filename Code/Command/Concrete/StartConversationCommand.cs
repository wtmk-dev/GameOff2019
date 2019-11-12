public class StartConversationCommand : ICommand
{
    private ScreenDirector screenDirector;

    private ScreenID previousScreen;

    private PlayerController playerController;

    public CMD Command()
    {
        return CMD.StartConversation;
    }

    public StartConversationCommand(ScreenDirector screenDirector, PlayerController playerController)
    {
        this.screenDirector = screenDirector;
        this.playerController = playerController;
    }

    public void Execute() 
    {
        previousScreen = screenDirector.currentScreen;
        screenDirector.HideScreen(previousScreen);
        screenDirector.ShowScreen(ScreenID.Conversation);
        screenDirector.HideScreen(ScreenID.StartConversation);

        playerController.isActive = false;
        playerController.NpcInteraction();
    }
    public void Unexecute()
    {
        screenDirector.ShowScreen(previousScreen);
        screenDirector.HideScreen(ScreenID.Conversation);
        screenDirector.ShowScreen(ScreenID.StartConversation);

        playerController.isActive = true;
    }
}