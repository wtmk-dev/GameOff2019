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
    private Button btnOptionA, btnOptionB, btnContinue, btnEndConversation;

    private ScreenID id = ScreenID.Conversation;

    private List<NPC> npcs;

    private IInvoker invoker;

    private Conversation npcModel;

    private Choice choice;

    public void Init(IInvoker invoker)
    {
        this.invoker = invoker;
        npcs = new List<NPC>();

        btnOptionA.onClick.AddListener( () => invoker.GetCommand(CMD.OptionA).Execute() );
        btnOptionB.onClick.AddListener( () => invoker.GetCommand(CMD.OptionB).Execute() );

        btnEndConversation.onClick.AddListener( () => invoker.GetCommand(CMD.EndConversation).Execute() );
        btnContinue.onClick.AddListener( () => invoker.GetCommand(CMD.ContinueConversation).Execute() );

        btnEndConversation.gameObject.SetActive(false);
        btnContinue.gameObject.SetActive(false);
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
        npc.OnMakeChoice += DisplayResponse;
        npc.OnEndConversation += EndConversation;
    }

    private void RegisterEvents()
    {
        foreach(NPC npc in npcs)
        {
            npc.OnDisplayActiveChoice      += DisplayActiveChoice;
            npc.OnHideActiveChoice += HideActiveChoice;
            npc.OnMakeChoice += DisplayResponse;
            npc.OnEndConversation += EndConversation;
        }
    }

    private void DeregisterEvents()
    {
        foreach(NPC npc in npcs)
        {
            npc.OnDisplayActiveChoice      -= DisplayActiveChoice;
            npc.OnHideActiveChoice -= HideActiveChoice;
            npc.OnMakeChoice -= DisplayResponse;
            npc.OnEndConversation -= EndConversation;
        }
    }

    //events
    private void DisplayActiveChoice(Choice convo)
    {
        tmpNpcText.gameObject.SetActive(true); 
        tmpOptionTextA.gameObject.SetActive(true); 
        tmpOptionTextB.gameObject.SetActive(true);

        btnOptionA.gameObject.SetActive(true); 
        btnOptionB.gameObject.SetActive(true);
        
        btnContinue.gameObject.SetActive(false); 
        btnEndConversation.gameObject.SetActive(false);


        tmpNpcText.text = convo.question;
        tmpOptionTextA.text = convo.answerA;
        tmpOptionTextB.text = convo.answerB;
    }

    private void HideActiveChoice(Choice convo)
    {
       
    }

    private void DisplayResponse(CMD cmd, Choice choice)
    {
        tmpNpcText.text = choice.GetResponse(cmd);

        btnOptionA.gameObject.SetActive(false);
        btnOptionB.gameObject.SetActive(false);

        if(choice.CheckForNextChoice(cmd))
        {
            btnContinue.gameObject.SetActive(true);
        }else {
            btnEndConversation.gameObject.SetActive(true);
        }

    }

    private void EndConversation()
    {
        tmpNpcText.gameObject.SetActive(false); 
        tmpOptionTextA.gameObject.SetActive(false); 
        tmpOptionTextB.gameObject.SetActive(false);

        btnOptionA.gameObject.SetActive(false); 
        btnOptionB.gameObject.SetActive(false);
        
        btnContinue.gameObject.SetActive(false); 
        btnEndConversation.gameObject.SetActive(false);
    }
}
