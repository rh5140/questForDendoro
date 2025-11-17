using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class NameToNpcMap : MonoBehaviour
{
    [SerializeField] NameToNpc[] npcArray;
    public Dictionary<string, TalkInteraction> npcDict;

    void Awake()
    {
        npcDict = new Dictionary<string, TalkInteraction>();
        foreach (NameToNpc npc in npcArray)
        {
            npcDict.Add(npc.npcName, npc.ti);
        }
    }
}
