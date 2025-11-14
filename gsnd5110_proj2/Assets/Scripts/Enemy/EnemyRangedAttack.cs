using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField] float radius;

    [SerializeField] GameObject projectileTarget;
    [SerializeField] float delayToClearTarget;
    Vector3 targetPosition;

    [SerializeField] GameObject projectile;

    public void UseRangedAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            CharacterHealth currTarget = hitCollider.transform.GetComponent<CharacterHealth>();

            if (hitCollider.gameObject.tag == "Player" && currTarget != null)
            {
                targetPosition = new Vector3(hitCollider.transform.position.x, 0.01f, hitCollider.transform.position.z);
                GameObject currentTarget = Instantiate(projectileTarget, targetPosition, projectileTarget.transform.rotation);

                GameObject currProjectile = Instantiate(projectile, transform.position, transform.rotation);
                currProjectile.GetComponent<EnemyProjectile>().SetTargetPosition(targetPosition);

                Destroy(currentTarget, delayToClearTarget);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
