using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _curHealth;

    void OnEnable()
    {
        _curHealth = _maxHealth;
    }

    public void HealDamage(int heal)
    {
        _curHealth += heal;
        if (_curHealth > _maxHealth) _curHealth = _maxHealth;
    }

    public void ReceiveDamage(int dmg)
    {
        _curHealth -= dmg;
        if (_curHealth <= 0) Die();
    }

    private void Die()
    {
        _curHealth = 0;
        if (gameObject.tag != "Player")
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Debug.Log("player dies");
        }
    }
}
