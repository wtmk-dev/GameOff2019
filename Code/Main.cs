using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> goGameScreens;
    private List<IScreen> screens;

    private ScreenDirector screenDirector;

    private Invoker cmdInvoker;

    void Awake()
    {
        screens = new List<IScreen>();
        screenDirector = new ScreenDirector();
        cmdInvoker = new Invoker();

        LoadGameScreens();
        InitCommands();
    }

    void Start()
    {
        
        screenDirector.ShowScreen(ScreenID.Start);
    }

    private void LoadGameScreens()
    {
        foreach(GameObject go in goGameScreens)
        {
            IScreen screen = go.GetComponent<IScreen>();
            screens.Add(screen);
            screenDirector.LoadScreen(screen);
        }
    }

    private void InitCommands()
    {
        cmdInvoker.SetCommand( new StartGameCommand(screenDirector) );

        foreach(IScreen screen in screens)
        {
            screen.Init(cmdInvoker);
        }
    }

}
