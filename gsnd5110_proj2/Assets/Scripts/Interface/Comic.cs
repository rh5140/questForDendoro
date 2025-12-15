using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Comic : MonoBehaviour
{
    [SerializeField] GameObject[] comicStates;
    int currIdx = 1;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] sfx;
    [SerializeField] AudioClip lastPageFlip;
    [SerializeField] AudioClip intro;
    [SerializeField] AudioClip portal;
    [SerializeField] bool isTwist = false;
    [SerializeField] bool triggersBoss = false;
    [SerializeField] BossController boss;
    [SerializeField] bool triggersMusic = false;
    [SerializeField] TriggerMusic musicTrigger;
    [SerializeField] bool changeScene = false;
    [SerializeField] string newScene;
    [SerializeField] bool changeSword = false;
    [SerializeField] PlayerData playerData;
    
    bool buffered = false;
    float bufferTime = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ChangeToNextState()
    {
        if (buffered) return;
        if (currIdx == comicStates.Length)
        {
            audioSource.PlayOneShot(lastPageFlip);
            if (triggersBoss) boss.StartBoss();
            if (triggersMusic) musicTrigger.StartMusic();
            if (changeScene) SceneManager.LoadScene(newScene);
            if (changeSword) playerData.hasSword = true;
            foreach (GameObject state in comicStates)
            {
                state.SetActive(false);
            }
            GetComponent<Image>().enabled = false;
            MusicManager.Instance.ResetVolume();
            Destroy(gameObject, 10f);
        }
        else
        {
            buffered = true;
            StartCoroutine(WaitForBuffer());
            comicStates[currIdx].SetActive(true);
            currIdx++;
            if (isTwist && currIdx == 4) 
            {
                MusicManager.Instance.StopAudio();
                MusicManager.Instance.PlayOnce(intro);
                StartCoroutine(WaitForIntro());
            }
            PlayRandomSfx();
        }
    }

    private void PlayRandomSfx()
    {
        int idx = Random.Range(0, sfx.Length);
        audioSource.PlayOneShot(sfx[idx]);
    }

    IEnumerator WaitForBuffer()
    {
        yield return new WaitForSeconds(bufferTime);
        buffered = false;
    }

    IEnumerator WaitForIntro()
    {
        float introLength = 8.0924f;
        yield return new WaitForSecondsRealtime(introLength + 0.15f);
        MusicManager.Instance.ChangeTrack(portal);
    }
}
