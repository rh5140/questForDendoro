using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] CompanionProjectile projectile;
    [SerializeField] private float _interval = 0.5f;
    private float _currTime = 1f;

    void Update()
    {
        _currTime += Time.deltaTime;
    }

    public void Attack()
    {
        if (_currTime < _interval) return;
        else
        {
            Instantiate(projectile, transform);
            _currTime = 0;
        }
    }
}
