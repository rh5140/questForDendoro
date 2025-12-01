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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        attackPosition = attackTransform.position;
        lungePosition = startPosition + lungeVector;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (_currHealth >= 0 && currTime > attackInterval)
        {
            StartCoroutine(Lunge());
            currTime = 0;
        }
    }

    private IEnumerator Lunge()
    {
        attackIndicator.color = Color.white;
        float moveDuration = 0.5f;
        float moveTime = 0;
        animator.SetTrigger("Attack");
        while (moveTime < moveDuration)
        {
            moveTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, lungePosition, 2);
            yield return null;
        }
        StartCoroutine(Attack());
        yield return new WaitForSeconds(1f);   
        moveTime = 0;
        while (moveTime < moveDuration)
        {
            moveTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 2);
            yield return null;
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
        animator.SetTrigger("Dead");
        Destroy(gameObject, 2f);
    }
}