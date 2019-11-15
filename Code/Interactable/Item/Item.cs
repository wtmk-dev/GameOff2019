using System;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public event Action<Item> OnUseItem;
    public event Action<Item> OnRewardItem;
    public event Action<Item> OnItemInpscted;

    public string _name;
    public string discription;
    public Vector3 position;
    
    public void UseItem()
    {
        if( OnUseItem != null )
        {
            OnUseItem(this);
        }
    }

    public void RewardItem()
    {
        if( OnRewardItem != null )
        {
            OnRewardItem(this);
        }
    }

    public void Inspect()
    {
        if( OnItemInpscted != null )
        {
            OnItemInpscted(this);
        }
    }

}