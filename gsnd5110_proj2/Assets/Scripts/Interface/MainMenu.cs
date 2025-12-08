using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sfx;

    public void ShowGameObject(GameObject go)
    {
        go.SetActive(true);
    }

    public void HideGameObject(GameObject go)
    {
        go.SetActive(false);
    }

    public void PlaySfx()
    {
        audioSource.PlayOneShot(sfx);
    }
}
