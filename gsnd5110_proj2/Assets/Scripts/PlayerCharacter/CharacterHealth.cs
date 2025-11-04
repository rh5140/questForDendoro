using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currHealth;
    [SerializeField] private bool _isInvincible = false;
    [SerializeField] private float _iFrames = 0.5f;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private HeartsInterface _hearts;

    private string _scene;

    void OnEnable()
    {
        _currHealth = _maxHealth;
        _scene = SceneManager.GetActiveScene().name;
    }

    public void HealDamage(int heal)
    {
        int actualHeal = Mathf.Min(_maxHealth - _currHealth, heal);
        _currHealth += actualHeal;
        _hearts.AddHearts(actualHeal);
    }

    public void ReceiveDamage(int dmg)
    {
        if (_isInvincible) return;
        _hearts.RemoveHearts(dmg);
        _currHealth -= dmg;
        if (_currHealth <= 0) Die();
        if (!_isInvincible) StartCoroutine(BecomeTemporarilyInvincible());
    }

    public int GetCurrhealth()
    {
        return _currHealth;
    }

    protected virtual void Die()
    {
        _currHealth = 0;
        SceneManager.LoadScene(_scene);
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
