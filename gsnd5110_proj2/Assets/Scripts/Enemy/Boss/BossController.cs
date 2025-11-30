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
        Destroy(transform.parent.gameObject);
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
}
