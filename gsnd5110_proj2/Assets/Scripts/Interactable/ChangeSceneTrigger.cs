using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour
{
    [SerializeField] string nextScene; 
    [SerializeField] float waitTime = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DelayBeforeEnable(waitTime));
        }
    }

    IEnumerator DelayBeforeEnable(float wait = 5f)
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(nextScene);
    }
}
