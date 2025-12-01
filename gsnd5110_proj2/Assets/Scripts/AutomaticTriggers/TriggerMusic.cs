using System.Collections;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip intro;
    [SerializeField] AudioClip loop;
    bool started = false;

    void OnTriggerEnter(Collider other)
    {
        if (started) return;
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayIntroThenLoop());
            started = true;
        }
    }

    IEnumerator PlayIntroThenLoop(float introLength = 8.3f)
    {
        audioSource.clip = intro;
        audioSource.Play();
        yield return new WaitForSeconds(introLength);
        Debug.Log("hi");
        audioSource.clip = loop;
        audioSource.Play();
        yield return null;
    }
}
