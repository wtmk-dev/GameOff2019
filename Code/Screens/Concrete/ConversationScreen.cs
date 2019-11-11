using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConversationScreen : MonoBehaviour , IScreen
{
    [SerializeField]
    private TextMeshProUGUI tmpNpcText, tmpOptionTextA, tmpOptionTextB;

    [SerializeField]
    private Button btnOptionA, btnOptionB;

    private ScreenID id = ScreenID.Conversation;

    private IInvoker invoker;

    private NPCStrategy npcModel;

    public void Init(IInvoker invoker)
    {
        this.invoker = invoker;
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

    public void SetActiveNpc(NPC npc)
    {
        npcModel =  npc.GetStrategy();

        tmpNpcText.text = npcModel.conversations[npc.conversationIndex];

        tmpOptionTextA.text = npcModel.choiceAs[npc.conversationIndex];
        tmpOptionTextB.text = npcModel.choiceBs[npc.conversationIndex];
    }
}
