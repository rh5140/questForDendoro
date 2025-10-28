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

    // Temporary code for prototype
    public GameObject winScreen;    
    private InputAction _bossCheat;

    void OnEnable()
    {
        _currHealth = _maxHealth;
        _bossCheat = InputSystem.actions.FindAction("BossCheat");

        _bossCheat.performed += DamageCheat;
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
        if (!_isInvincible) StartCoroutine(BecomeTemporarilyInvincible());
    }

    private void DamageCheat(InputAction.CallbackContext ctx)
    {
        ReceiveDamage(1);
    }

    protected virtual void Die()
    {
        _currHealth = 0;
        Destroy(transform.parent.gameObject);

        // Temporary code for prototype
        winScreen.SetActive(true);

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
        _bossCheat.performed -= DamageCheat;
    }
}
