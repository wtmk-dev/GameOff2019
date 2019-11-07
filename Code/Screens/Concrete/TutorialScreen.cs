using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private List<TextMeshProUGUI> textMeshPros;

    [SerializeField]
    private ScreenID id = ScreenID.Tutorial;

    private IInvoker invoker;

    public void Init(IInvoker invoker)
    {
        this.invoker = invoker;
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
