using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClone : MonoBehaviour
{
   //this needs to just be IInteractables
    [SerializeField]
    private SphereCollider pickUpCollider;
    private Item item;

    public void Init(Item item)
    {
        this.item = item;
    }

    public void Inspect()
    {
       item.Inspect();
    }
}
