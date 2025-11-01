using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Vector3 center;
    [SerializeField] float range;
    [SerializeField] Vector3 hitboxSize;

    public void Start()
    {
        center = transform.position;
        range = 2f;
        hitboxSize = new Vector3(range, range, range);
    }

    public void HitTarget()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, hitboxSize);
        foreach (var hitCollider in hitColliders)
        {
            EnemyController currTarget = hitCollider.transform.GetComponent<EnemyController>();
            if (hitCollider.gameObject.tag == "Enemy" && currTarget != null)
            {
                currTarget.ReceiveDamage(damage);
            }
        }
        // RaycastHit hit;
        // if (Physics.BoxCast(transform.position, new Vector3(range, range, range), transform.forward, out hit))
        // {
        //     EnemyController currTarget = hit.transform.GetComponent<EnemyController>();
        //     if (hit.collider.gameObject.tag == "Enemy" && currTarget != null)
        //     {
        //         Debug.Log("YEAH");
        //         currTarget.ReceiveDamage(damage);
        //     }
        // }
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);

        Gizmos.DrawWireCube(transform.position, new Vector3(range, range, range));
    }
}
