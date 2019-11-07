using System.Collections.Generic;

public class Invoker : IInvoker
{
    private Dictionary<CMD, ICommand> commands;

    public Invoker()
    {
        commands = new Dictionary<CMD, ICommand>();
    }

    public void SetCommand(ICommand command)
    {
        commands.Add(command.Command(),command);
    }

    public ICommand GetCommand(CMD cmd)
    {
        return commands[cmd];
    }
}