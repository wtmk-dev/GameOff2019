using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldMapScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private TextMeshProUGUI tmpClock, tmpFlavor;
    
    private IInvoker invoker;

    public void Init(IInvoker invoker)
    {
        this.invoker = invoker;
        // btnEngageInConversation.onClick.AddListener( );
    }
    
//interface
    public ScreenID GetID()
    {
        return ScreenID.Main;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
//

    
}
