using UnityEngine;

public class Weapon : MonoBehaviour
{
    Health currTarget = null;
    [SerializeField] int damage;

    public void HitTarget()
    {
        if (currTarget != null) currTarget.ReceiveDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            currTarget = other.gameObject.GetComponent<Health>();
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
