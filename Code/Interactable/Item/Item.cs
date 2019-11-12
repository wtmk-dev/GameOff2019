using System;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public event Action<string> OnUseItem;
    public string _name;
    public string discription;
    
    public void UseItem()
    {
        if( OnUseItem != null )
        {
            OnUseItem( _name );
        }
    }

}