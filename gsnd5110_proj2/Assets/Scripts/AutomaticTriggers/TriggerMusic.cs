using System.Collections;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    [SerializeField] AudioSource introOnly;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip intro;
    [SerializeField] AudioClip loop;
    bool started = false;

    // void OnTriggerEnter(Collider other)
    // {
    //     if (started) return;
    //     if (other.gameObject.tag == "Player")
    //     {
    //         StartCoroutine(PlayIntroThenLoop());
    //         started = true;
    //     }
    // }

    public void StartMusic()
    {
        Debug.Log("Start music");
        StartCoroutine(PlayIntroThenLoop());
    }

    IEnumerator PlayIntroThenLoop(float introLength = 8.0924f)
    {
        Debug.Log("Play intro then loop");
        audioSource.clip = loop;
        introOnly.Play();
        yield return new WaitForSecondsRealtime(introLength + 0.15f);
        MusicManager.Instance.ChangeTrack(loop);
        yield return null;
    }
}
