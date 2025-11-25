using UnityEngine;

public class BubbleOnProximity : MonoBehaviour
{
    [SerializeField] GameObject dialogueBubble;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("SOMETHING ENTERED");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OO player");
            dialogueBubble.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("SOMETHING EXITED");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("bye  player");
            dialogueBubble.SetActive(false);
        }
    }
}
