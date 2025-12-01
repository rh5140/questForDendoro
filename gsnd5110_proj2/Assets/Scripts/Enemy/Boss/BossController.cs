using System.Collections;
using UnityEngine;

enum BossState
{
    Moving,
    Attacking,
    Dying
}

public class BossController : EnemyController
{
    [SerializeField] GameObject[] attackList;
    [SerializeField] float attackInterval = 10f;
    private float currTime = 0f;

    private BossState currState = BossState.Moving;
    [SerializeField] MoveTo moveTo;

    bool isAttacking = false;
    int currAttackIdx = 0;
    EnemyAOE currAttack;

    [SerializeField] GameObject shadowSprite;

    void Update()
    {
        switch (currState)
        {
            case BossState.Moving:
                moveTo.MoveToTarget();
                break;
            case BossState.Attacking:
                break;
            case BossState.Dying:
                break;
            default:
                break;
        }
        if (!isAttacking && currTime > attackInterval)
        {
            moveTo.StopMoving();
            isAttacking = true;
            currState = BossState.Attacking;
            BossAttack();
        }
        if (currAttack != null && currState == BossState.Attacking)
        {
            if (currAttack.IsAttackCompleted())
            {
                isAttacking = false;
                currTime = 0f;
                currState = BossState.Moving;
            }
        }
        currTime += Time.deltaTime;
    }

    protected override void Die()
    {
        _currHealth = 0;
        currState = BossState.Dying;
        StartCoroutine(DeathSequence());
    }

    protected int RandomAttack()
    {
        return Random.Range(0, attackList.Length);
    }

    protected void BossAttack()
    {
        currAttackIdx = RandomAttack();
        currAttack = attackList[currAttackIdx].GetComponent<EnemyAOE>();
        currAttack.UseAttack();
    }

    IEnumerator DeathSequence()
    {
        shadowSprite.SetActive(false);
        _sr.color = Color.red;

        float time = 0;
        float duration = 1f;

        while (time < duration)
        {
            _sr.color = Color.Lerp(Color.red, Color.clear, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _sr.color = Color.clear;
        Destroy(transform.parent.gameObject);
    }
}
