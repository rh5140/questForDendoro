using UnityEngine;

public class SetUpMusic : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audioClip != MusicManager.Instance.GetCurrentClip())
        {
            MusicManager.Instance.ChangeTrack(audioClip);
        }
    }
}
