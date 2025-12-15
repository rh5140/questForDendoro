using System.Collections;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    [SerializeField] AudioSource introOnly;
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
        StartCoroutine(PlayIntroThenLoop());
    }

    IEnumerator PlayIntroThenLoop(float introLength = 8.0924f)
    {
        MusicManager.Instance.StopAudio();
        introOnly.Play();
        yield return new WaitForSecondsRealtime(introLength + 0.15f);
        MusicManager.Instance.ChangeTrack(loop);
        yield return null;
    }
}
