using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> goGameScreens;

    private ScreenDirector screenDirector;

    void Awake()
    {
        screenDirector = new ScreenDirector();
    }

    void Start()
    {
        LoadGameScreens( goGameScreens );

        screenDirector.ShowScreen(ScreenID.Start);
    }

    private void LoadGameScreens( List<GameObject> gos )
    {
        foreach(GameObject go in gos)
        {
            IScreen screen = go.GetComponent<IScreen>();
            screenDirector.LoadScreen(screen);
        }
    }


}
