public class ContinueConversationCommand : ICommand
{

    private PlayerController playerController;


    public CMD Command()
    {
        return CMD.ContinueConversation;
    }

    public ContinueConversationCommand(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Execute() 
    {
        playerController.NpcInteraction( );
    }

    public void Unexecute()
    {
        
    }
}