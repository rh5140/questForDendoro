using UnityEngine;

public class CompanionProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 3f;
    [SerializeField] private int _damage = 1;
    [SerializeField] float range = 1f;
    [SerializeField] Vector3 hitboxSize;
    int shootRight = 1;
    [SerializeField] SpriteRenderer _sr;

    private float _currTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitboxSize = new Vector3(range, range, range);
    }

    public void SetDirection(int dir)
    {
        shootRight = dir;
        if (dir < 0) _sr.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currTime >= _lifetime) Destroy(gameObject);
        transform.Translate(Vector3.right * shootRight *_speed * Time.deltaTime);
        Collider[] hitColliders = Physics.OverlapBox(transform.position, hitboxSize);
        foreach (var hitCollider in hitColliders)
        {
            EnemyController currTarget = hitCollider.transform.GetComponent<EnemyController>();
            if (hitCollider.gameObject.tag == "Enemy" && currTarget != null)
            {
                currTarget.ReceiveDamage(_damage);
                Destroy(gameObject);
            }
        }
        _currTime += Time.deltaTime;
    }
}
