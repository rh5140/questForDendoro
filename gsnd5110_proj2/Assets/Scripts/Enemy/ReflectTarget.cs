using UnityEngine;

public class ReflectTarget : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition;
    [SerializeField] EnemyProjectile projectilePrefab;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "FriendlyProjectile")
        {
            EnemyProjectile currProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            currProjectile.SetTargetPosition(transform.position + targetPosition);
        }
    }

    public void ShootAtTarget(Vector3 newPosition, int damage = 1)
    {
        EnemyProjectile currProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        currProjectile.SetTargetPosition(newPosition);
        currProjectile.SetDamage(damage);
    }
}
