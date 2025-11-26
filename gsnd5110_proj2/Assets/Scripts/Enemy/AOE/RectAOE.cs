using System.Collections;
using UnityEngine;

public class RectAOE : MonoBehaviour
{
    [SerializeField] int damage;

    public float interval = 1f;
    private float currTime = 0f;
    
    [SerializeField] Vector3 hitboxSize;
    [SerializeField] SpriteRenderer rangeIndicator; // change to shader if time
    [SerializeField] GameObject hitboxGO;

    bool isDisplaying = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDisplaying && currTime < interval - 2.95f && currTime > interval - 3.05f)
        {
            isDisplaying = true;
            StartCoroutine(IncreaseOpacity());
        }
        if (currTime > interval)
        {
            Collider[] hitColliders = Physics.OverlapBox(hitboxGO.transform.position, hitboxSize, hitboxGO.transform.rotation);
            foreach (var hitCollider in hitColliders)
            {
                CharacterHealth currTarget = hitCollider.transform.GetComponent<CharacterHealth>();
                if (hitCollider.gameObject.tag == "Player" && currTarget != null)
                {
                    currTarget.ReceiveDamage(damage);
                }
            }
            currTime = 0;
            rangeIndicator.color = new Color(rangeIndicator.color.r, rangeIndicator.color.b, rangeIndicator.color.g, 0f);
            isDisplaying = false;
        }
        currTime += Time.deltaTime;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);

        Gizmos.DrawWireCube(hitboxGO.transform.position, hitboxSize);
    }
}
