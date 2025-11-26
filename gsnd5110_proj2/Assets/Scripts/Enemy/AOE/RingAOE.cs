using System.Collections;
using UnityEngine;

public class RingAOE : MonoBehaviour
{
    [SerializeField] int damage;

    public float interval = 1f;
    private float currTime = 0f;
    
    [SerializeField] float radius;
    [SerializeField] float innerRadius;
    [SerializeField] SpriteRenderer rangeIndicator; // change to shader if time
    bool isDisplaying = false;
    bool inSafeZone = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDisplaying && currTime < interval - 0.95f && currTime > interval - 1.05f)
        {
            isDisplaying = true;
            StartCoroutine(IncreaseOpacity());
        }
        if (currTime > interval)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, innerRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Player")
                {
                    inSafeZone = true;
                }
            }
            hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var hitCollider in hitColliders)
            {
                CharacterHealth currTarget = hitCollider.transform.GetComponent<CharacterHealth>();
                if (!inSafeZone && hitCollider.gameObject.tag == "Player" && currTarget != null)
                {
                    currTarget.ReceiveDamage(damage);
                }
            }
            currTime = 0;
            rangeIndicator.color = new Color(rangeIndicator.color.r, rangeIndicator.color.b, rangeIndicator.color.g, 0f);
            isDisplaying = false;
            inSafeZone = false;
        }
        currTime += Time.deltaTime;
    }

    IEnumerator IncreaseOpacity(float duration = 1f)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = new Color(0f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, innerRadius);
    }

}
