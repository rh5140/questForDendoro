using UnityEngine;

public class PlaySoundOnAwake : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    void OnEnable()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
    }
}
