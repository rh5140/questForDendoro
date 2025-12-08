using System.Collections;
using UnityEngine;

public class EnableGameObject : MonoBehaviour
{
    [SerializeField] GameObject targetGO; 
    [SerializeField] float waitTime = 0f;
    bool enabled = false;

    void OnTriggerEnter(Collider other)
    {
        if (!enabled && other.gameObject.tag == "Player")
        {
            StartCoroutine(DelayBeforeEnable(waitTime));
            enabled = true;
        }
    }

    IEnumerator DelayBeforeEnable(float wait = 0f)
    {
        yield return new WaitForSeconds(wait);
        targetGO.SetActive(true);
        // Destroy(gameObject);
    }
}
