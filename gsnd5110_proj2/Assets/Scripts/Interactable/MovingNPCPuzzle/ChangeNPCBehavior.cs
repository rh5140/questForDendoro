using UnityEngine;

public class ChangeNPCBehavior : MonoBehaviour
{
    bool changedDialogue = false;
    [SerializeField] GameObject npcStart;
    [SerializeField] GameObject npcEnd;
    public NPCFakeTeleport nft;
    public PressurePlate pp;

    void OnTriggerEnter(Collider collider)
    {
        if (!changedDialogue)
        {
            ChangeDialogue("Oh! I can stand on a pressure plate.");
            nft.enabled = true;
            changedDialogue = true;
            nft.activated = true;
        }
    }

    void ChangeDialogue(string newDialogue)
    {
        npcStart.GetComponentInChildren<BubbleOnProximity>().dialogue = newDialogue;
        npcStart.GetComponentInChildren<BubbleOnProximity>().RefreshDialogueImmediate();
    }

    public void ChangePositions()
    {
        npcStart.SetActive(false);
        npcEnd.SetActive(true);
        pp.isReady = true;
    }
}
