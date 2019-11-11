using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public event Action<NPCStrategy> OnConversable;
    public event Action<NPCStrategy> OnExitConversation;
    [SerializeField]
    private GameObject rig, notificationIcon;
    [SerializeField]
    private SphereCollider conversationTrigger;

    private NPCStrategy model;

    public int conversationIndex;

    public void Init(NPCStrategy model)
    {
        this.model = model;
        conversationIndex = 0;

        SetTriggerRadius();
    }

    public NPCStrategy GetStrategy()
    {
        return model;
    }

    public void CheckInventoryForTriggers(List<string> inventory)
    {
        foreach(var item in inventory)
        {
            if(item == model.trigger)
            {
                notificationIcon.SetActive(true);

                if(OnConversable != null)
                {
                    OnConversable(model);
                }
            }
        }
    }

    public void ExitConversationRange()
    {
        notificationIcon.SetActive(false);

        if(OnConversable != null)
        {
            OnExitConversation(model);
        }   
    }

    private void SetTriggerRadius()
    {
        conversationTrigger.radius = model.cTriggerRadius;
    }


}
