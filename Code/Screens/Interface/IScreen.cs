using System;
using System.Collections.Generic;

public interface IScreen
{
    void Init(IInvoker invoker);
    ScreenID GetID();
    void Show();
    void Hide();
}
