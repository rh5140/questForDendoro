using UnityEngine;

public class BossController : EnemyController
{
    [SerializeField] GameObject[] attackList;
    [SerializeField] float attackInterval = 10f;
    private float currTime = 0f;

    bool isAttacking = false;
    int currAttackIdx = 0;
    EnemyAOE currAttack;

    void Update()
    {
        if (!isAttacking && currTime > attackInterval)
        {
            isAttacking = true;
            currAttackIdx = RandomAttack();
            currAttack = attackList[currAttackIdx].GetComponent<EnemyAOE>();
            currAttack.UseAttack();
        }
        if (currAttack != null && isAttacking)
        {
            isAttacking = !currAttack.IsAttackCompleted();
        }
        currTime += Time.deltaTime;
    }

    protected override void Die()
    {
        _currHealth = 0;
        Destroy(transform.parent.gameObject);
    }

    protected int RandomAttack()
    {
        return Random.Range(0, attackList.Length);
    }
}
