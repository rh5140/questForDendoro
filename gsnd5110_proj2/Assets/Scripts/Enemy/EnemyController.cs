using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currHealth;

    void OnEnable()
    {
        _currHealth = _maxHealth;
    }

    public void HealDamage(int heal)
    {
        _currHealth += heal;
        if (_currHealth > _maxHealth) _currHealth = _maxHealth;
    }

    public void ReceiveDamage(int dmg)
    {
        _currHealth -= dmg;
        if (_currHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        _currHealth = 0;
        Destroy(transform.parent.gameObject);
    }

}
