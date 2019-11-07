using System.Collections.Generic;

public class ScreenDirector
{
    private Dictionary<ScreenID,IScreen> loadedScreens;

    public ScreenID currentScreen;

    public ScreenDirector()
    {
        loadedScreens = new Dictionary<ScreenID,IScreen>();
    }

    public void LoadScreen(IScreen screen)
    {
        loadedScreens.Add(screen.GetID(), screen);
        screen.Hide();
    }

    public void ShowScreen(ScreenID screenID)
    {
        loadedScreens[screenID].Show();
        currentScreen = screenID;
    }

    public void HideScreen(ScreenID screenID)
    {
        loadedScreens[screenID].Hide();
    }
}