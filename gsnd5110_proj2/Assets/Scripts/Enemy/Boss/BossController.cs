using System.Collections;
using TMPro;
using UnityEngine;

enum BossState
{
    Moving,
    Attacking,
    Dying,
    Idle,
}

public class BossController : EnemyController
{
    [SerializeField] GameObject[] attackList;
    [SerializeField] float attackInterval = 10f;
    private float currTime = 0f;

    private BossState currState = BossState.Idle;
    [SerializeField] MoveTo moveTo;

    bool isAttacking = false;
    int currAttackIdx = 0;
    EnemyAOE currAttack;

    [SerializeField] GameObject shadowSprite;

    [SerializeField] GameObject dialogueBubble;
    [SerializeField] TextMeshPro dialogueTMP;
    [SerializeField] string deathLine;

    // [SerializeField] bool isQueen = false;
    // [SerializeField] Sprite normalQueen;

    [SerializeField] GameObject healthUI;
    [SerializeField] HealthBar healthBar;

    [SerializeField] GameObject endDialogue;

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
                moveTo.StopMoving();
                break;
            case BossState.Idle:
                break;
            default:
                break;
        }
        if (currState != BossState.Idle && !isAttacking && currTime > attackInterval)
        {
            moveTo.StopMoving();
            isAttacking = true;
            currState = BossState.Attacking;
            BossAttack();
        }
        if (currState != BossState.Dying && currAttack != null && currState == BossState.Attacking)
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

    
    public override void ReceiveDamage(int dmg)
    {
        if (currState == BossState.Idle) return;
        base.ReceiveDamage(dmg);
        if (!healthUI.activeSelf) healthUI.SetActive(true);
        healthBar.SetHealth(_currHealth);
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

        float time = 0;
        float duration = 1f;

        while (time < duration)
        {
            // if (isQueen && time < duration / 2) _sr.sprite = normalQueen;
            _sr.color = Color.Lerp(Color.red, Color.clear, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _sr.color = Color.clear;
        endDialogue.SetActive(true);
        Destroy(transform.parent.gameObject, 1f);
    }

    // public void BossDialogue(string line)
    // {
    //     dialogueBubble.SetActive(true);
    //     dialogueTMP.text = line;
    //     healthUI.SetActive(true);
    //     StartCoroutine(DelayBeforeContinue());
    // }

    public void StartBoss()
    {
        healthUI.SetActive(true);
        currState = BossState.Moving;
    }

    IEnumerator DelayBeforeContinue(float waitSeconds = 5f)
    {
        yield return new WaitForSeconds(waitSeconds);
        dialogueBubble.SetActive(false);
        if (_currHealth > 0) currState = BossState.Moving;
    }
}
