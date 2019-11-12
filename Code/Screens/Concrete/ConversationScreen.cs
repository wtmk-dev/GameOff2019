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

    private List<NPC> npcs;

    private IInvoker invoker;

    private Conversation npcModel;

    private Choice choice;

    public void Init(IInvoker invoker)
    {
        this.invoker = invoker;
        npcs = new List<NPC>();
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

    public void DisplayActiveChoice()
    {
        tmpNpcText.text = choice.question;

        tmpOptionTextA.text = choice.answerA;
        tmpOptionTextB.text = choice.answerB;
    }

    public void RegiserterNPC(NPC npc)
    {
        npcs.Add(npc);
        npc.OnDisplayActiveChoice      += DisplayActiveChoice;
        npc.OnHideActiveChoice += HideActiveChoice;
    }

    private void RegisterEvents()
    {
        foreach(NPC npc in npcs)
        {
            npc.OnDisplayActiveChoice      += DisplayActiveChoice;
            npc.OnHideActiveChoice += HideActiveChoice;
        }
    }

    private void DeregisterEvents()
    {
        foreach(NPC npc in npcs)
        {
            npc.OnDisplayActiveChoice      -= DisplayActiveChoice;
            npc.OnHideActiveChoice -= HideActiveChoice;
        }
    }

    //events
    private void DisplayActiveChoice(Choice convo)
    {
        tmpNpcText.text = convo.question;
        tmpOptionTextA.text = convo.answerA;
        tmpOptionTextB.text = convo.answerB;
    }

    private void HideActiveChoice(Choice convo)
    {
       
    }
}
