using UnityEngine;

public class Weapon : MonoBehaviour
{
    // EnemyController currTarget = null;
    [SerializeField] int damage;
    [SerializeField] Vector3 center;
    [SerializeField] float range;

    public void Start()
    {
        center = transform.position;
        range = 2f;
    }

    public void HitTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            EnemyController currTarget = hit.transform.GetComponent<EnemyController>();
            if (hit.collider.gameObject.tag == "Enemy" && currTarget != null)
            {
                currTarget.ReceiveDamage(damage);
            }
        }
    }
}
