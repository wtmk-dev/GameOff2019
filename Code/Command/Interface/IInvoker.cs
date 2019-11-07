using System.Collections.Generic;


public interface IInvoker
{
    void SetCommand(ICommand command);
    ICommand GetCommand(CMD commandType);
}
