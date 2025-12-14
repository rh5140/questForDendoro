using System.Collections;
using UnityEngine;

public class RingAOE : EnemyAOE
{
    [SerializeField] float innerRadius;
    bool inSafeZone = false;

    protected override void CheckOverlapForDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, innerRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Player")
            {
                inSafeZone = true;
            }
        }
        hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            CharacterHealth currTarget = hitCollider.transform.GetComponent<CharacterHealth>();
            if (!inSafeZone && hitCollider.gameObject.tag == "Player" && currTarget != null)
            {
                currTarget.ReceiveDamage(damage);
            }
        }
        inSafeZone = false;
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = new Color(0f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, innerRadius);
    }

}
