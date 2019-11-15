using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Conversation : ScriptableObject
{
    public float cTriggerRadius;
    public string _name;
    public List<Item> triggers;
    public List<Choice> choices;
    public Vector3 position;
}
