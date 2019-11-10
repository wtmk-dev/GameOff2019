using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class NPCFactory 
{
    public NPCFactory(string data)
    {
        ParseJSON(data);
    }

    private void ParseJSON(string data)
    {
        var json = JSON.Parse(data);
        Debug.Log(json);
    }
}
