using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    SpriteRenderer sr;
    public bool isReady = false;
    public bool works = false;
    public UnlockGate ug;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.color = Color.orange;
            if (works && isReady) ug.Raise();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.color = Color.white;
        }
    }
}
