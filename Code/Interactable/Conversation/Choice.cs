using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Choice : ScriptableObject
{
    public string question;
    public string answerA;
    public string answerB;
    public string responseA;
    public string responseB;

    public bool isNested;
    public bool usesTriggerItem;
    public bool willReward;

    public List<Item> rewardsA;
    public List<Item> rewardsB;
    public List<Item> useTriggerItemA;
    public List<Item> useTriggerItemB;

    public CMD nestTrigger;

    public string GetResponse(CMD choice)
    {
        string response = "";

        if(choice == CMD.OptionA)
        {
            response = responseA;
        }

        if(choice == CMD.OptionB)
        {
            response = responseB;
        }

        return response;
    }

    public bool CheckForNextChoice(CMD choice)
    {
        bool check = false;
        if(isNested)
        {
            if(choice == nestTrigger)
            {
                check = true;
            }
        }

        return check;
    }

    public void UseTriggerItem(CMD choice)
    {
        if(choice == CMD.OptionA)
        {
            foreach(var item in useTriggerItemA)
            {
                item.UseItem();   
            }
        }

        if(choice == CMD.OptionB)
        {
            foreach(var item in useTriggerItemB)
            {
                item.UseItem();   
            }
        }
    }

    public void RewardItem(CMD choice)
    {
        if(choice == CMD.OptionA)
        {
            foreach(var item in rewardsA)
            {
                item.RewardItem();   
            }
        }

        if(choice == CMD.OptionB)
        {
            foreach(var item in rewardsB)
            {
                item.RewardItem();   
            }
        }
    }

}
