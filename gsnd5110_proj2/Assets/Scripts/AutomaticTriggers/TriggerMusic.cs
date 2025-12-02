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

    IEnumerator PlayIntroThenLoop(float introLength = 8.0924f)
    {
        audioSource.Stop();
        audioSource.clip = intro;
        audioSource.PlayOneShot(intro);
        yield return new WaitForSeconds(introLength);
        audioSource.clip = loop;
        audioSource.Play();
        yield return null;
    }
}
