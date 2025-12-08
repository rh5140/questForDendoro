using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSfx()
    {
        if (clips.Length == 0)
        {
            Debug.Log("No audio clips found!");
            return;
        }
        int idx = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[idx]);
    }
}
