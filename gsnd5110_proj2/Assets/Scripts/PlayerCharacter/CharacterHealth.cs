using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currHealth;
    [SerializeField] private bool _isInvincible = false;
    [SerializeField] private float _iFrames = 0.5f;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private HeartsInterface _hearts;

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
        _hearts.RemoveHearts(dmg);
        _currHealth -= dmg;
        if (_currHealth <= 0) Die();
        if (!_isInvincible) StartCoroutine(BecomeTemporarilyInvincible());
    }

    protected virtual void Die()
    {
        _currHealth = 0;
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        _isInvincible = true;
        _sr.color = Color.red;
        yield return new WaitForSeconds(_iFrames);
        _sr.color = Color.white;
        _isInvincible = false;
    }

}
