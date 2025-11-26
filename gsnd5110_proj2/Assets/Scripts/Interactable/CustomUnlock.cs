using UnityEngine;

public class CustomGate : MonoBehaviour
{
    [SerializeField] UnlockGate ug;
    public bool destroyOnTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        Destroy(this);
    }

    void OnDestroy()
    {
        ug.Raise();
    }
}
