using UnityEngine;
using UnityEngine.UI;

public class Comic : MonoBehaviour
{
    [SerializeField] GameObject[] comicStates;
    int currIdx = 1;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] sfx;
    [SerializeField] AudioClip lastPageFlip;
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
            audioSource.PlayOneShot(lastPageFlip);
            foreach (GameObject state in comicStates)
            {
                state.SetActive(false);
            }
            GetComponent<Image>().enabled = false;
            Destroy(gameObject, 5f);
        }
        else
        {
            comicStates[currIdx].SetActive(true);
            currIdx++;
            if (isTwist && currIdx == 4) audioSource.PlayOneShot(intro);
            PlayRandomSfx();
        }
    }

    private void PlayRandomSfx()
    {
        int idx = Random.Range(0, sfx.Length);
        audioSource.PlayOneShot(sfx[idx]);
    }
}
