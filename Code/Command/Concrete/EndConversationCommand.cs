
public class EndConversationCommand : ICommand
{
    private PlayerController playerController;

    public CMD Command()
    {
        return CMD.EndConversation;
    }

    public EndConversationCommand(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Execute() 
    {
        playerController.EndConversation();
        playerController.isActive = true;
    }

    public void Unexecute()
    {
        
    }
}