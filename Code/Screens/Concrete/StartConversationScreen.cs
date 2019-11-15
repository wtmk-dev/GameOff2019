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
    private Button btnEngageInConversation, btnPickUpItem;

    private IInvoker invoker;

    private List<NPC> npcs;
    private List<Item> items;

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
        items = new List<Item>();

        btnEngageInConversation.onClick.AddListener( () => invoker.GetCommand(CMD.StartConversation).Execute() );
        //btnPickUpItem.onClick.AddListener( () => invoker.GetCommand(CMD.PickUpItem).Execute() );

        btnEngageInConversation.gameObject.SetActive(false);
        btnPickUpItem.gameObject.SetActive(false);
    }
//

    public void RegiserterNPC(NPC npc)
    {
        npcs.Add(npc);
        npc.OnConversable      += DisplayConversationInformation;
        npc.OnExitConversation += HideConversationInformation;
    }

    public void RegisterItem(Item item)
    {
        items.Add(item);
        item.OnItemInpscted += DisplayInspectedItem;
    }

    private void RegisterEvents()
    {
        foreach(NPC npc in npcs)
        {
            npc.OnConversable      += DisplayConversationInformation;
            npc.OnExitConversation += HideConversationInformation;
        }

        foreach(var item in items)
        {
            item.OnItemInpscted += DisplayInspectedItem;
        }
    }

    private void DeregisterEvents()
    {
        foreach(NPC npc in npcs)
        {
            npc.OnConversable      -= DisplayConversationInformation;
            npc.OnExitConversation -= HideConversationInformation;
        }

        foreach(var item in items)
        {
            item.OnItemInpscted -= DisplayInspectedItem;
        }
    }

//events
    private void DisplayInspectedItem(Item item)
    {
        tmpNpcName.text = item._name;

        btnEngageInConversation.gameObject.SetActive(false);
        btnPickUpItem.gameObject.SetActive(true);
    }

    private void DisplayConversationInformation(Conversation convo)
    {
        tmpNpcName.text = convo._name;

        btnEngageInConversation.gameObject.SetActive(true);
        btnPickUpItem.gameObject.SetActive(false);
    }

    private void HideConversationInformation(Conversation convo)
    {
        tmpNpcName.text = "";

        btnEngageInConversation.gameObject.SetActive(false);
        btnPickUpItem.gameObject.SetActive(false);
    }
}
