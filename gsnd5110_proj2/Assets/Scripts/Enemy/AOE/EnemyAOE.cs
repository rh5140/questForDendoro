using System.Collections;
using UnityEngine;

public class EnemyAOE : MonoBehaviour
{
    [SerializeField] protected int damage;
    protected float currTime = 0f;
    [SerializeField] protected float warningTime = 3f;
    
    [SerializeField] protected float radius;
    [SerializeField] SpriteRenderer rangeIndicator; // change to shader if time
    bool attackCompleted = true;

    public void UseAttack()
    {
        if (!attackCompleted) return;
        attackCompleted = false;
        StartCoroutine(IncreaseOpacity(warningTime));
        StartCoroutine(WaitBeforeAttack());
    }

    IEnumerator IncreaseOpacity(float duration = 3f)
    {
        float time = 0;
        Color startValue = rangeIndicator.color;
        Color endValue = new Color(startValue.r, startValue.b, startValue.g, 1f);

        while (time < duration)
        {
            rangeIndicator.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        rangeIndicator.color = endValue;
    }

    IEnumerator WaitBeforeAttack()
    {
        yield return new WaitForSeconds(warningTime);
        CheckOverlapForDamage();
        rangeIndicator.color = new Color(rangeIndicator.color.r, rangeIndicator.color.b, rangeIndicator.color.g, 0f);
        attackCompleted = true;
    }

    protected virtual void CheckOverlapForDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            CharacterHealth currTarget = hitCollider.transform.GetComponent<CharacterHealth>();
            if (hitCollider.gameObject.tag == "Player" && currTarget != null)
            {
                currTarget.ReceiveDamage(damage);
            }
        }
    }

    public bool IsAttackCompleted()
    {
        return attackCompleted;
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);

        Gizmos.DrawSphere(transform.position, radius);
    }
}
