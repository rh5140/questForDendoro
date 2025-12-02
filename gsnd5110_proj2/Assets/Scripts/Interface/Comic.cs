using UnityEngine;
using UnityEngine.UI;

public class Comic : MonoBehaviour
{
    [SerializeField] GameObject[] comicStates;
    int currIdx = 0;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sfx;
    [SerializeField] AudioClip intro;
    [SerializeField] bool isTwist = false;
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
            if (isTwist && currIdx == 4) audioSource.PlayOneShot(intro);
            audioSource.PlayOneShot(sfx);
        }
    }
}
