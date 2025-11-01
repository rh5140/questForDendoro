using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage;

    public float interval = 1f;
    private float currTime = 0f;
    
    [SerializeField] Vector3 hitboxSize;

    // Update is called once per frame
    void Update()
    {
        if (currTime > interval)
        {
            Collider[] hitColliders = Physics.OverlapBox(transform.position, hitboxSize);
            foreach (var hitCollider in hitColliders)
            {
                CharacterHealth currTarget = hitCollider.transform.GetComponent<CharacterHealth>();
                if (hitCollider.gameObject.tag == "Player" && currTarget != null)
                {
                    currTarget.ReceiveDamage(damage);
                }
            }
            currTime = 0;
        }
        currTime += Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);

        Gizmos.DrawWireCube(transform.position, hitboxSize);
    }
}
