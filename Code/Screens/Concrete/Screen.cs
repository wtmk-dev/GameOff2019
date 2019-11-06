using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Screen : MonoBehaviour, IScreen
{
    [SerializeField]
    private ScreenID id; 

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
}
