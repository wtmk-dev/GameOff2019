using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private GameObject model, conversationTrigger, notificationIcon;
    private float cTriggerRadius;
    private string opener;
    private int conversationIndex;
    private List<string> conversations;
    private List<string> choiceAs;
    private List<string> choiceBs;
}
