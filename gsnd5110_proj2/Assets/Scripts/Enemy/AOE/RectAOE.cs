using System.Collections;
using UnityEngine;

public class RectAOE : EnemyAOE
{
    [SerializeField] Vector3 hitboxSize;
    [SerializeField] GameObject hitboxGO;

    protected override void CheckOverlapForDamage()
    {
        Collider[] hitColliders = Physics.OverlapBox(hitboxGO.transform.position, hitboxSize, hitboxGO.transform.rotation);
        foreach (var hitCollider in hitColliders)
        {
            CharacterHealth currTarget = hitCollider.transform.GetComponent<CharacterHealth>();
            if (hitCollider.gameObject.tag == "Player" && currTarget != null)
            {
                currTarget.ReceiveDamage(damage);
            }
        }
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);

        Gizmos.DrawWireCube(hitboxGO.transform.position, hitboxSize);
    }
}
