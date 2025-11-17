using UnityEngine;
using Yarn.Unity;
using System.Collections;

public class TalkInteraction : Interactable
{
    [SerializeField] DialogueRunner dr;
    [SerializeField] string startNode;
    bool onCooldown = false;

    public void Awake()
    {
        // dr.AddCommandHandler<float>(
        //     "interaction_cooldown",     // the name of the command
        //     InteractionCooldown // the method to run
        // );
    }

    public override void RunInteraction()
    {
        if (!onCooldown)
        {
            onCooldown = true;
            dr.StartDialogue(startNode);
        }
    }

    public void InteractionCooldown()
    {
        StartCoroutine(StartCooldown());
    }

    public IEnumerator StartCooldown()
    {
        float cooldownTime = 3f;
        float currTime = 0f;
        while (currTime < cooldownTime)
        {
            currTime += Time.deltaTime;
            yield return null;
        }
        onCooldown = false;
    }
}
