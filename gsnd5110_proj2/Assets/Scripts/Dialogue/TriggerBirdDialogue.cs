using System.Collections;
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
            StartCoroutine(DisableBubble());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("EXIT");
            dialogueBubble.SetActive(false);
            Destroy(gameObject);
        }
    }

    IEnumerator DisableBubble()
    {
        yield return new WaitForSeconds(5f);
        dialogueBubble.SetActive(false);
    }
}
