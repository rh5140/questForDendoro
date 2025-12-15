using System.Collections;
using UnityEngine;

public class NPCFakeTeleport : MonoBehaviour
{
    public ChangeNPCBehavior cnb;
    public bool activated = false;
    bool alreadyRunning = false;
    [SerializeField] Animator movementAnimator;
    [SerializeField] Animator wobbleAnimator;

    void OnTriggerEnter(Collider collider)
    {
        if (!alreadyRunning && activated && collider.gameObject.tag == "Player")
        {
            alreadyRunning = true;
            StartCoroutine(MoveToLocation());
            Destroy(this, 6f);
        }
            
    }

    void OnDestroy()
    {
        cnb.ChangePositions();
    }

    IEnumerator MoveToLocation()
    {
        yield return new WaitForSeconds(3f);
        movementAnimator.SetTrigger("Move");
        wobbleAnimator.SetTrigger("Wobble");
    }
}
