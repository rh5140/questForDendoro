using UnityEngine;
using UnityEngine.UI;

public class Comic : MonoBehaviour
{
    [SerializeField] GameObject[] comicStates;
    int currIdx = 0;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sfx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ChangeToNextState()
    {
        if (currIdx == comicStates.Length)
        {
            Destroy(gameObject);
        }
        else
        {
            comicStates[currIdx].SetActive(true);
            currIdx++;
            audioSource.PlayOneShot(sfx);
        }
    }
}
