public class ConversationChoiceCommand : ICommand
{
    private ScreenID previousScreen;

    private PlayerController playerController;

    private CMD choice;

    public CMD Command()
    {
        return choice;
    }

    public ConversationChoiceCommand(PlayerController playerController, CMD choice)
    {
    
        this.playerController = playerController;
        this.choice = choice;
    }

    public void Execute() 
    {
        playerController.MakeChoice( choice );
    }

    public void Unexecute()
    {
        
    }
}