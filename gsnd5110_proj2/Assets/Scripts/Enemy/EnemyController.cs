using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    protected int _currHealth;
    
    [SerializeField] protected bool _isInvincible = false;
    [SerializeField] protected float _iFrames = 0.2f;
    [SerializeField] protected SpriteRenderer _sr;

    protected virtual void OnEnable()
    {
        _currHealth = _maxHealth;
    }

    public void HealDamage(int heal)
    {
        _currHealth += heal;
        if (_currHealth > _maxHealth) _currHealth = _maxHealth;
    }

    public virtual void ReceiveDamage(int dmg)
    {
        if (_currHealth <= 0) return;
        if (_isInvincible) return;
        _currHealth -= dmg;
        if (_currHealth <= 0) Die();
        if (!_isInvincible) StartCoroutine(BecomeTemporarilyInvincible());
    }

    protected virtual void Die()
    {
        _currHealth = 0;
        Destroy(transform.gameObject);
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        _isInvincible = true;
        if (_sr != null && _currHealth > 0) _sr.color = Color.red;
        yield return new WaitForSeconds(_iFrames);
        _isInvincible = false;
        if (_sr != null) _sr.color = Color.white;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

}
