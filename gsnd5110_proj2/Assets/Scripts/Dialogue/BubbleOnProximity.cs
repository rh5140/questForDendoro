using System.Collections;
using TMPro;
using UnityEngine;

public class BubbleOnProximity : MonoBehaviour
{
    [SerializeField] GameObject dialogueBubble;
    [SerializeField] TextMeshPro dialogueTMP;
    [SerializeField] string dialogue;
    [SerializeField] string hitReaction;

    void Awake()
    {
        dialogueTMP.text = dialogue;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(false);
        }
    }

    public void ReactToHit()
    {
        dialogueTMP.text = hitReaction;
        StartCoroutine(RefreshDialogue());
    }

    IEnumerator RefreshDialogue()
    {
        yield return new WaitForSeconds(2f);
        dialogueTMP.text = dialogue;
    }
}
