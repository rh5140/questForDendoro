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
    [SerializeField] bool isTwist = false;
    [SerializeField] bool triggersBoss = false;
    [SerializeField] BossController boss;
    [SerializeField] bool triggersMusic = false;
    [SerializeField] TriggerMusic musicTrigger;
    [SerializeField] bool changeScene = false;
    [SerializeField] string newScene;
    [SerializeField] bool changeSword = false;
    [SerializeField] PlayerData playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ChangeToNextState()
    {
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
            Destroy(gameObject, 10f);
        }
        else
        {
            comicStates[currIdx].SetActive(true);
            currIdx++;
            if (isTwist && currIdx == 4) 
            {
                MusicManager.Instance.StopAudio();
                audioSource.PlayOneShot(intro);
            }
            PlayRandomSfx();
        }
    }

    private void PlayRandomSfx()
    {
        int idx = Random.Range(0, sfx.Length);
        audioSource.PlayOneShot(sfx[idx]);
    }
}
