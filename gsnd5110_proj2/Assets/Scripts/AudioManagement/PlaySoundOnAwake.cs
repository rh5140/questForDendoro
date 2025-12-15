using UnityEngine;

public class PlaySoundOnAwake : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    void OnEnable()
    {
        MusicManager.Instance.DropVolume();
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
    }
}
