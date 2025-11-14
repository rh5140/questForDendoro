using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Vector3 targetPosition;
    [SerializeField] float speed = 5f;
    [SerializeField] int damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        Collider[] hitColliders = Physics.OverlapBox(transform.position, new Vector3(1f,1f,1f));
        foreach (var hitCollider in hitColliders)
        {
            CharacterHealth currTarget = hitCollider.transform.GetComponent<CharacterHealth>();
            if (hitCollider.gameObject.tag == "Player" && currTarget != null)
            {
                currTarget.ReceiveDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    public void SetTargetPosition(Vector3 newPosition)
    {
        targetPosition = newPosition;
        Destroy(gameObject, 5f); // super jank
    }
}
