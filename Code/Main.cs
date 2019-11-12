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

    [SerializeField]
    private GameObject npcPrefab, playerPrefab;
    private GameObjectPooler npcPooler;

    [SerializeField]
    private List<Conversation> npcs;

    private PlayerController playerController;

    private string NPC_DATAPAT = "NPCDATA.json";

    void Awake()
    {
        //GameObject player = Instantiate(playerPrefab,new Vector3(0,0,0),Quaternion.identity);     
        playerPrefab.SetActive(true);
        playerController = playerPrefab.GetComponent<PlayerController>();

        npcPooler = new GameObjectPooler();
        screens = new List<IScreen>();
        screenDirector = new ScreenDirector();
        cmdInvoker = new Invoker();

        LoadGameScreens();
    //Init
        InitCommands();
    //Build
        BuildNPCInteractables();

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

    // private void LoadeNPCData()
    // {
    //     var data = File.ReadAllText(Application.streamingAssetsPath + "\\" + NPC_DATAPAT);
    //     npcFactory = new NPCFactory();
    // }

    private void InitCommands()
    {
        cmdInvoker.SetCommand( new StartGameCommand(screenDirector, playerController) );
        cmdInvoker.SetCommand( new StartConversationCommand(screenDirector, playerController) );

        foreach(IScreen screen in screens)
        {
            screen.Init(cmdInvoker);
        }
    }

    private void BuildNPCInteractables()
    {
        StartConversationScreen scs = (StartConversationScreen) GetScreen(ScreenID.StartConversation);
        ConversationScreen convoScreen = (ConversationScreen) GetScreen(ScreenID.Conversation);

        foreach(Conversation npc in npcs)
        {
            GameObject clone = Instantiate(npcPrefab, new Vector3(0,0,0), Quaternion.identity);

            NPC cloneNPC = clone.GetComponent<NPC>();
            cloneNPC.Init(npc);

            npcPooler.SetPoolable(clone);
            clone.SetActive(true);

            scs.RegiserterNPC( cloneNPC );
            convoScreen.RegiserterNPC( cloneNPC );
        }

        
    }

    private IScreen GetScreen(ScreenID id)
    {
        foreach(IScreen screen in screens)
        {
            if(screen.GetID() == id)
            {
                return screen;
            }
        }

        return null;
    }

}
