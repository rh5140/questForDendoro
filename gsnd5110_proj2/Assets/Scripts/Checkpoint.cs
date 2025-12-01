using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] EndScreen endScreen;
    void Start()
    {
        if (endScreen == null) endScreen = GameObject.Find("Canvas").GetComponent<EndScreen>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            endScreen.SetNewStartingPosition(transform.position + new Vector3(0,1f,0));
            Destroy(gameObject);
        }
    }
}
