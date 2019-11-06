using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private List<Button> buttons;
    [SerializeField]
    private ScreenID id = ScreenID.Start;

    void Awake() 
    {
        foreach(Button button in buttons)
        {
            AssignButtonCmd(button);
        }
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

    private void AssignButtonCmd(Button button)
    {
        switch(button.name)
        {
            default:
                button.onClick.AddListener( () => gameObject.SetActive(false) );
                break;
        }
    }

}
