using TMPro;
using UnityEngine;

public class TriggerBirdDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogueBubble;
    [SerializeField] TextMeshPro dialogueTMP;
    [SerializeField] string line;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(true);
            dialogueTMP.text = line;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(false);
            Destroy(gameObject, 10f);
        }
    }
}
