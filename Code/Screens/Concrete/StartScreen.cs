using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private List<Button> buttons;
    [SerializeField]
    private ScreenID id = ScreenID.Start;

    private IInvoker invoker;

    public void Init(IInvoker invoker)
    {
        this.invoker = invoker;
        AssignButtonCmds();
    }

    void Awake()
    {
        
    }

    void Start()
    {
       
    }

    public ScreenID GetID()
    {
        return id;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void AssignButtonCmds()
    {
        foreach(Button button in buttons)
        {
            switch(button.name)
            {
                default:
                    button.onClick.AddListener( () => invoker.GetCommand(CMD.StartGame).Execute() );
                    break;
            }
        }
    }

}
