using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] CompanionProjectile projectile;
    [SerializeField] private float _interval = 0.5f;
    private float _currTime = 0;

    void Start()
    {
    }

    void Update()
    {
        _currTime += Time.deltaTime;
    }

    public void Attack()
    {
        if (_currTime < _interval) return;
        else
        {
            CompanionProjectile newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            if (transform.localPosition.x > 0) newProjectile.SetDirection(-1);
            _currTime = 0;
        }
    }
}
