using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    CharacterHealth currTarget = null;
    [SerializeField] int damage;

    public float interval = 1f;
    private float currTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (currTime > interval)
        {
            if (currTarget != null) currTarget.ReceiveDamage(damage);
            currTime = 0;
        }
        currTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currTarget = other.gameObject.GetComponent<CharacterHealth>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            currTarget = null;
        }
    }
}
