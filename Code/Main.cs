using System;
using System.IO;
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

    private NPCFactory npcFactory;

    private string NPC_DATAPAT = "NPCDATA.json";

    void Awake()
    {
        screens = new List<IScreen>();
        screenDirector = new ScreenDirector();
        cmdInvoker = new Invoker();

        LoadeNPCData();
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

    private void LoadeNPCData()
    {
        var data = File.ReadAllText(Application.dataPath + "\\" + NPC_DATAPAT);
        npcFactory = new NPCFactory(data);
    }

}
