using UnityEngine;
using System.Collections;

public class MimicEnemy : EnemyController
{
    EnemyRangedAttack rangeAttack;
    float currTime = 3;
    [SerializeField] float attackInterval = 5f;
    Vector3 startPosition;
    Vector3 jumpPosition;
    PlayRandomAudio randomAudio;
    [SerializeField] GameObject shadowSprite;
    [SerializeField] GameObject deadSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rangeAttack = GetComponent<EnemyRangedAttack>();
        startPosition = transform.position;
        jumpPosition = new Vector3(startPosition.x, startPosition.y + 5, startPosition.z);
        randomAudio = GetComponent<PlayRandomAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > attackInterval && _currHealth > 0)
        {
            StartCoroutine(Jump());
            currTime = 0;
        }
    }

    private IEnumerator Jump()
    {
        float jumpDuration = 0.5f;
        float jumpTime = 0;

        while (jumpTime < jumpDuration)
        {
            jumpTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, jumpPosition, 2);
            yield return null;
        }
        StartCoroutine(Attack());
        yield return new WaitForSeconds(0.5f);   
        jumpTime = 0;
        while (jumpTime < jumpDuration)
        {
            jumpTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 2);
            yield return null;
        }
    }
    
    public override void ReceiveDamage(int dmg)
    {
        if (_currHealth > 0) PlaySFX();
        base.ReceiveDamage(dmg);
    }

    private IEnumerator Attack()
    {
        rangeAttack.UseRangedAttack();
        yield return null;
    }

    private void PlaySFX()
    {
        randomAudio.PlayRandomSfx();
    }

    protected override void Die()
    {
        StartCoroutine(DeathSequence());
    }
    
    private IEnumerator DeathSequence()
    {
        GetComponent<BoxCollider>().enabled = false;

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
}
