using UnityEngine;

public class CustomGate : MonoBehaviour
{
    [SerializeField] UnlockGate ug;
    public bool destroyOnTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        Destroy(this);
    }

    void OnDestroy()
    {
        ug.Raise();
    }
}
