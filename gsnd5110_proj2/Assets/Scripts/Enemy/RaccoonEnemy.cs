using UnityEngine;
using System.Collections;

public class RaccoonEnemy : EnemyController
{
    Vector3 startPosition;
    [SerializeField] Vector3 lungeVector;
    Vector3 lungePosition;
    float currTime = 0;
    [SerializeField] int attackDamage = 1;
    [SerializeField] float attackInterval = 5f;
    [SerializeField] SpriteRenderer attackIndicator;
    [SerializeField] Transform attackTransform;
    Vector3 attackPosition;
    [SerializeField] Vector3 hitboxSize;
    [SerializeField] Animator animator;

    [SerializeField] GameObject shadowSprite;
    [SerializeField] GameObject deadSprite;
    [SerializeField] GameObject bodyHitbox;
    [SerializeField] SpriteRenderer attackRange;

    private PlayRandomAudio randomAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        attackPosition = attackTransform.position;
        lungePosition = startPosition + lungeVector;
        randomAudio = GetComponent<PlayRandomAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (_currHealth > 0 && currTime > attackInterval)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(Lunge());
            currTime = 0;
        }
    }

    private IEnumerator Lunge()
    {
        float time = 0;
        float duration = 0.5f;
        while (time < duration)
        {
            attackRange.color = Color.Lerp(Color.clear, Color.white, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        attackRange.color = Color.clear;
        float moveDuration = 0.5f;
        float moveTime = 0;
        while (moveTime < moveDuration)
        {
            moveTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, lungePosition, 2);
            yield return null;
        }
        StartCoroutine(Attack());
        yield return new WaitForSeconds(1f);   
        moveTime = 0;
        if (_currHealth > 0)
        {
            while (moveTime < moveDuration)
            {
                moveTime += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, startPosition, 2);
                yield return null;
            }
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        Collider[] hitColliders = Physics.OverlapBox(attackPosition, hitboxSize);
        foreach (var hitCollider in hitColliders)
        {
            EnemyController currTarget = hitCollider.transform.GetComponent<EnemyController>();
            if (hitCollider.gameObject.tag == "Player" && currTarget != null)
            {
                currTarget.ReceiveDamage(attackDamage);
            }
        }
        attackIndicator.color = Color.clear;
    }

    protected override void Die()
    {
        StartCoroutine(DeathSequence());
    }

    private IEnumerator DeathSequence()
    {
        animator.SetTrigger("Dead");
        bodyHitbox.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        
        shadowSprite.SetActive(false);
        deadSprite.SetActive(true);

        float time = 0;
        float duration = 2f;

        SpriteRenderer _sr = deadSprite.GetComponent<SpriteRenderer>();

        while (time < duration)
        {
            _sr.color = Color.Lerp(Color.white, Color.clear, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _sr.color = Color.clear;
        Destroy(gameObject);
    }

    public override void ReceiveDamage(int dmg)
    {
        if (_currHealth > 0) PlaySFX();
        base.ReceiveDamage(dmg);
    }

    private void PlaySFX()
    {
        randomAudio.PlayRandomSfx();
    }
}