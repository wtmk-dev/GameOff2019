using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{   
    public delegate void EndConversationEvent();
    public event EndConversationEvent OnEndConversation;
    public event Action<CMD,Choice> OnMakeChoice;
    public event Action<Conversation> OnConversable;
    public event Action<Conversation> OnExitConversation;
    public event Action<Choice> OnDisplayActiveChoice;
    public event Action<Choice> OnHideActiveChoice;

    [SerializeField]
    private GameObject rig, notificationIcon;
    [SerializeField]
    private SphereCollider conversationTrigger;
    [SerializeField]
    private Conversation conversation;

    public int conversationIndex;

    public void Init(Conversation model)
    {
        this.conversation = model;
        conversationIndex = 0;

        SetTriggerRadius();
    }

    public Conversation GetStrategy()
    {
        return conversation;
    }

    public void ActiveChoice()
    {
        if(OnDisplayActiveChoice != null)
        {
            OnDisplayActiveChoice(conversation.choices[conversationIndex]);
        }
    }

    public void MakeChoice(CMD choice)
    {
        if( conversationIndex < conversation.choices.Count )
        {
            if(OnMakeChoice != null)
            {
                OnMakeChoice(choice,conversation.choices[conversationIndex]);
            }

            if(conversation.choices[conversationIndex].usesTriggerItem)
            {
                conversation.choices[conversationIndex].UseTriggerItem(choice);
            }

            if(conversation.choices[conversationIndex].willReward)
            {
                conversation.choices[conversationIndex].RewardItem(choice);
            }

            conversationIndex++;
        }
    }

    public void EndConversation()
    {
        if(OnEndConversation != null)
        {
            OnEndConversation();
        }

        notificationIcon.SetActive(false);

        conversationIndex = -1;
    }

    public void CheckInventoryForTriggers(List<Item> inventory)
    {
        int amountOfConvoTriggers = conversation.triggers.Count;
        int triggered = 0;

        if(amountOfConvoTriggers == 0)
        {
            notificationIcon.SetActive(true);

            if(OnConversable != null)
            {
                OnConversable(conversation);
                return;
            }
        } 

        foreach(var item in inventory)
        {
            foreach(var trigger in conversation.triggers)
            {
                if( item == trigger )
                {
                    triggered++;
                }

                if( triggered == amountOfConvoTriggers )
                {
                    notificationIcon.SetActive(true);

                    if(OnConversable != null)
                    {
                        OnConversable(conversation);
                        break;
                    }
                }
            }
        }
    }

    public void ExitConversationRange()
    {
        notificationIcon.SetActive(false);

        if(OnConversable != null)
        {
            OnExitConversation(conversation);
        }   
    }

    private void SetTriggerRadius()
    {
        conversationTrigger.radius = conversation.cTriggerRadius;
    }


}
