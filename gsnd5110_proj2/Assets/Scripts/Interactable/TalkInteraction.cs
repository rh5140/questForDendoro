using UnityEngine;
using Yarn.Unity;

public class TalkInteraction : Interactable
{
    [SerializeField] DialogueRunner dr;
    public override void RunInteraction()
    {
        Debug.Log("Start Dialogue");
        dr.StartDialogue("NpcDialogue");
    }
}
