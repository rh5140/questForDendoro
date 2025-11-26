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
}
