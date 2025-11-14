using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem; // TEMPORARY

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currHealth;
    
    [SerializeField] private bool _isInvincible = false;
    [SerializeField] private float _iFrames = 0.2f;
    [SerializeField] private SpriteRenderer _sr;


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
        _sr.color = Color.red;
        yield return new WaitForSeconds(_iFrames);
        _sr.color = Color.white;
        _isInvincible = false;
    }

    void OnDisable()
    {
    }
}
