using System.Collections.Generic;

public class NPCStrategy
{
    public float cTriggerRadius;
    public string name;
    public string trigger;
    public List<string> conversations;
    public List<string> choiceAs;
    public List<string> choiceBs;

    public Dictionary<string,string> response;

    public NPCStrategy (string name, float cTriggerRadius,List<string> conversations,List<string> choiceAs,List<string> choiceBs, Dictionary<string,string> response,Dictionary<string,string> rewards,string trigger)
    {
        this.conversations  = new List<string>();
        this.choiceAs       = new List<string>();
        this.choiceBs       = new List<string>();

        
        this.name = name;
        this.trigger = trigger;
        this.choiceAs = choiceAs; 
        this.choiceBs = choiceBs;
        this.cTriggerRadius = cTriggerRadius; 
        this.conversations = conversations; 
    }



}