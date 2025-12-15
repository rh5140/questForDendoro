using UnityEngine;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] DialogueRunner dr;
    [SerializeField] string startNode;
    [SerializeField] InputHandler player;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueCanvas.SetActive(true);
            StartDialogue(startNode);
        }
    }

    void StartDialogue(string node)
    {
        player.ChangePlayerToDialogue();
        dr.StartDialogue(node);
    }
}
