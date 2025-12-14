using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool useSingleton = true;
    
    public void PlayRandomSfx()
    {
        if (clips.Length == 0)
        {
            Debug.Log("No audio clips found!");
            return;
        }
        int idx = Random.Range(0, clips.Length);
        if (useSingleton) MusicManager.Instance.PlayOnce(clips[idx]);
        else audioSource.PlayOneShot(clips[idx]);
    }
}
