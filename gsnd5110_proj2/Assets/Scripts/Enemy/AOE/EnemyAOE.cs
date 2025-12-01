using System.Collections;
using UnityEngine;

public class EnemyAOE : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float warningTime = 3f;
    
    [SerializeField] protected float radius;
    [SerializeField] SpriteRenderer rangeIndicator; // change to shader if time
    [SerializeField] SpriteRenderer rangeOutline;
    bool attackCompleted = true;

    public virtual void UseAttack()
    {
        if (!attackCompleted) return;
        attackCompleted = false;
        StartCoroutine(IncreaseOpacity(warningTime));
        StartCoroutine(WaitBeforeAttack());
    }

    IEnumerator IncreaseOpacity(float duration = 2f)
    {
        if (rangeOutline != null) rangeOutline.color = Color.white;
        float time = 0;
        Color startValue = rangeIndicator.color;
        Color endValue = Color.white;

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
        attackCompleted = true;
        rangeIndicator.color = Color.clear;
        if (rangeOutline != null) rangeOutline.color = Color.clear;
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
