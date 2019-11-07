﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldMapScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private List<TextMeshProUGUI> textMeshPros; 

    [SerializeField]
    private ScreenID id = ScreenID.Main;

    private IInvoker invoker;

    public void Init(IInvoker invoker)
    {
        this.invoker = invoker;
    }
    
    void Awake() 
    {
    
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

    private void AssignTMPValue(TextMeshProUGUI tmp)
    {
        switch(tmp.name)
        {
            default:
                //button.onClick.AddListener( () => gameObject.SetActive(false) );
                break;
        }
    }
}