using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currHealth;
    [SerializeField] private bool _isInvincible = false;
    [SerializeField] private float _iFrames = 0.5f;
    // [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private HeartsInterface _hearts;
    [SerializeField] AudioClip hurtSfx;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject animatedBody;
    [SerializeField] GameObject deadSprite;
    [SerializeField] CharacterController player;
    bool _isDead = false;

    private string _scene;

    [SerializeField] bool hasBirdHealing = false;
    [SerializeField] GameObject healingPotion;

    void OnEnable()
    {
        _currHealth = _maxHealth;
    }

    public void HealDamage(int heal)
    {
        int actualHeal = Mathf.Min(_maxHealth - _currHealth, heal);
        _currHealth += actualHeal;
        _hearts.AddHearts(actualHeal);
    }

    public void HealFull()
    {
        HealDamage(_maxHealth);
    }

    public void ReceiveDamage(int dmg)
    {
        if (_isDead) return;
        if (_isInvincible) return;
        playerAnimator.Play("Hurt");
        MusicManager.Instance.PlayOnce(hurtSfx);
        _hearts.RemoveHearts(dmg);
        _currHealth -= dmg;
        if (_currHealth <= 0) Die();
        if (!_isInvincible) StartCoroutine(BecomeTemporarilyInvincible());

        if (hasBirdHealing && _currHealth == 2) StartCoroutine(WaitToHeal());
    }

    public int GetCurrhealth()
    {
        return _currHealth;
    }

    protected virtual void Die()
    {
        _currHealth = 0;
        _isDead = true;
        StartCoroutine(DeathSequence());
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        _isInvincible = true;
        yield return new WaitForSeconds(_iFrames);
        _isInvincible = false;
    }

    private IEnumerator DeathSequence()
    {
        playerAnimator.Play("Dead");
        yield return new WaitForSeconds(0.5f);
        deadSprite.SetActive(true);
        animatedBody.SetActive(false);
        yield return new WaitForSeconds(1f);
        _gameOverScreen.SetActive(true);
    }

    public void SetPlayerAlive()
    {
        _isDead = false;
    }

    private IEnumerator WaitToHeal()
    {
        healingPotion.SetActive(true);
        yield return new WaitForSeconds(1f);
        HealDamage(1);
        healingPotion.SetActive(false);
    }

}
