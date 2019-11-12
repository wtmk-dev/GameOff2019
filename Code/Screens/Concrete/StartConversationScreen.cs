using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartConversationScreen : MonoBehaviour, IScreen
{   
    [SerializeField]
    private TextMeshProUGUI tmpNpcName;
    [SerializeField]
    private Button btnEngageInConversation;

    private IInvoker invoker;

    private List<NPC> npcs;

    void OnEnable()
    {
        if(npcs != null)
        {
            RegisterEvents();
        }
    }

    void OnDisable()
    {
        if(npcs != null)
        {
            DeregisterEvents();
        }
    }

//interface
    public ScreenID GetID()
    {
        return ScreenID.StartConversation;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Init(IInvoker invoker)
    {
        this.invoker = invoker;
        npcs = new List<NPC>();

        btnEngageInConversation.onClick.AddListener( () => invoker.GetCommand(CMD.StartConversation).Execute() );

        btnEngageInConversation.gameObject.SetActive(false);
    }
//

    public void RegiserterNPC(NPC npc)
    {
        npcs.Add(npc);
        npc.OnConversable      += DisplayConversationInformation;
        npc.OnExitConversation += HideConversationInformation;
    }

    private void RegisterEvents()
    {
        foreach(NPC npc in npcs)
        {
            npc.OnConversable      += DisplayConversationInformation;
            npc.OnExitConversation += HideConversationInformation;
        }
    }

    private void DeregisterEvents()
    {
        foreach(NPC npc in npcs)
        {
            npc.OnConversable      -= DisplayConversationInformation;
            npc.OnExitConversation -= HideConversationInformation;
        }
    }

//events
    private void DisplayConversationInformation(Conversation convo)
    {
        tmpNpcName.text = convo._name;

        btnEngageInConversation.gameObject.SetActive(true);
    }

    private void HideConversationInformation(Conversation convo)
    {
        tmpNpcName.text = "";

        btnEngageInConversation.gameObject.SetActive(false);
    }
}
