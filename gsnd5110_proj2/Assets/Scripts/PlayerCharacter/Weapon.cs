using UnityEngine;

public class Weapon : MonoBehaviour
{
    EnemyController currTarget = null;
    [SerializeField] int damage;

    public void HitTarget()
    {
        if (currTarget != null) currTarget.ReceiveDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            currTarget = other.gameObject.GetComponent<EnemyController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            currTarget = null;
        }
    }
}
