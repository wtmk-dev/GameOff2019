using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class NPCFactory 
{
    private List<NPCStrategy> NPCs;

    public NPCFactory(string data)
    {
        NPCs = new List<NPCStrategy>();
        ParseJSON(data);
    }

    public List<NPCStrategy> GetAllNPCs()
    {
        return NPCs;
    }

    private void ParseJSON(string data)
    {
       var json = JSON.Parse(data);

       int total = json["total"];
    
       string id;
       string name;
       string trigger;
       float cTriggerRadius = 1f;

       for(int i = 0; i < total; i++)
       {
            var conversations  = new List<string>();
        
            var choiceAs       = new List<string>();
            var choiceBs       = new List<string>();

            var response       = new Dictionary<string,string>();
            var rewards        = new Dictionary<string,string>();

           id = i.ToString();
           name = json[id]["name"];
           trigger = json[id]["trigger"];

           conversations.Add( json[id]["opener"] );
           
            var choiceA = json[id]["a"]["choice"];
            var choiceB = json[id]["b"]["choice"];

           choiceAs.Add( choiceA );
           choiceBs.Add( choiceB );

           response.Add( choiceA, json[id]["a"]["response"] );
           response.Add( choiceB, json[id]["b"]["response"] );

           var rewardA = json[id]["a"]["reward"];
           var rewardB = json[id]["b"]["reward"]; 

           if( rewardA != null )
           {
                rewards.Add( choiceA, rewardA );
           }

           if( rewardB != null )
           {
               rewards.Add( choiceB, rewardB );
           }
        
            var nestedConversationA = json[id]["a"]["nested"];

            if( nestedConversationA != null )
            {
                conversations.Add( json[id]["a"]["nested"]["opener"] );

                choiceA =  json[id]["a"]["nested"]["a"]["choice"]; 
                choiceB =  json[id]["a"]["nested"]["b"]["choice"];

                choiceAs.Add( choiceA );
                choiceBs.Add( choiceB );

                response.Add( choiceA, json[id]["a"]["nested"]["a"]["response"] );
                response.Add( choiceB, json[id]["a"]["nested"]["b"]["response"] );

                var nestedRewardA = json[id]["a"]["nested"]["a"]["reward"];
                var nestedRewardB = json[id]["a"]["nested"]["b"]["reward"];

                if( nestedRewardA != null )
                {
                    rewards.Add( choiceA, nestedRewardA );
                }

                if( nestedRewardB != null )
                {
                    rewards.Add( choiceB, nestedRewardB );
                }
            }

            var nestedConversationB = json[id]["b"]["nested"];

            if( nestedConversationB != null )
            {
                conversations.Add( json[id]["b"]["nested"]["opener"] );

                choiceA =  json[id]["b"]["nested"]["a"]["choice"]; 
                choiceB =  json[id]["b"]["nested"]["b"]["choice"];

                choiceAs.Add( choiceA );
                choiceBs.Add( choiceB );

                response.Add( choiceA, json[id]["b"]["nested"]["a"]["response"] );
                response.Add( choiceB, json[id]["b"]["nested"]["b"]["response"] );

                var nestedRewardA = json[id]["b"]["nested"]["a"]["reward"];
                var nestedRewardB = json[id]["b"]["nested"]["b"]["reward"];

                if( nestedRewardA != null )
                {
                    rewards.Add( choiceA, nestedRewardA );
                }

                if( nestedRewardB != null )
                {
                    rewards.Add( choiceB, nestedRewardB );
                }
            }

            NPCs.Add( new NPCStrategy(name,cTriggerRadius,conversations,choiceAs,choiceBs,response,rewards,trigger) );
       }

    }

}
