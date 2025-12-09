using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager Instance {get; set;}
    AudioSource audioSource;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayOnce(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void ChangeTrack(AudioClip audioClip)
    {
        StopAudio();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public AudioClip GetCurrentClip()
    {
        return audioSource.clip;
    }

    public void DropVolume()
    {
        audioSource.volume = 0.25f;
    }

    public void ResetVolume()
    {
        audioSource.volume = 1f;
    }
}
