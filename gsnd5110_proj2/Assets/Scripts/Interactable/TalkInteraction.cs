using UnityEngine;
using Yarn.Unity;
using System.Collections;

public class TalkInteraction : Interactable
{
    [SerializeField] DialogueRunner dr;
    [SerializeField] string startNode;
    bool onCooldown = false;

    public override void RunInteraction()
    {
        if (!onCooldown)
        {
            onCooldown = true;
            dr.StartDialogue(startNode);
            StartCoroutine(StartCooldown()); // not my preferred way of doing this..
        }
    }

    public IEnumerator StartCooldown()
    {
        float cooldownTime = 10f;
        float currTime = 0f;
        while (currTime < cooldownTime)
        {
            currTime += Time.deltaTime;
            yield return null;
        }
        onCooldown = false;
    }
}
