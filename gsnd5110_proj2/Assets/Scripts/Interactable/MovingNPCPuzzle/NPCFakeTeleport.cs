using UnityEngine;

public class NPCFakeTeleport : MonoBehaviour
{
    public ChangeNPCBehavior cnb;
    public bool activated = false;

    void OnTriggerEnter(Collider collider)
    {
        if (activated && collider.gameObject.tag == "Player")
        {
            Destroy(this, 6f);
        }
            
    }

    void OnDestroy()
    {
        cnb.ChangePositions();
    }
}
