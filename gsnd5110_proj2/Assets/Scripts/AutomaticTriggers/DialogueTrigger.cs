using UnityEngine;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogueRunner dr;
    [SerializeField] string startNode;
    
    void OnTriggerEnter(Collider other)
    {
        dr.StartDialogue(startNode);
    }
}
