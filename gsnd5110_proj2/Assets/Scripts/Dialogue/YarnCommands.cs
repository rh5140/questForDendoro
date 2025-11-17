using UnityEngine;
using Yarn.Unity;
using System.Collections;
using System.Collections.Generic;

public class YarnCommands : MonoBehaviour
{
    [SerializeField] DialogueRunner dr;
    [SerializeField] NameToNpcMap map;
    private Dictionary<string, TalkInteraction> dict;

    public void Start()
    {
        dr.AddCommandHandler<string>(
            "interaction_cooldown",     // the name of the command
            InteractionCooldown // the method to run
        );
        dict = map.npcDict;
    }

    public void InteractionCooldown(string npcName)
    {
        if (dict.ContainsKey(npcName))
        {
            dict[npcName].InteractionCooldown();
        }
        else Debug.Log("NPC " + npcName + " not found!");
    }

}
