using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBirdDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogueBubble;
    [SerializeField] TextMeshPro dialogueTMP;
    [SerializeField] string line;
    [SerializeField] bool changeScene = false;
    [SerializeField] string nextScene;
    private AudioSource audioSource;
    [SerializeField] AudioClip[] sfx;

    void OnAwake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(true);
            dialogueTMP.text = line;
            PlayRandomSfx();
            StartCoroutine(DisableBubble());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(false);
            Destroy(gameObject,5f);
        }
    }

    IEnumerator DisableBubble()
    {
        yield return new WaitForSeconds(5f);
        dialogueBubble.SetActive(false);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (changeScene) SceneManager.LoadScene(nextScene);
    }

    private void PlayRandomSfx()
    {
        if (sfx.Length == 0) return;
        int idx = Random.Range(0, sfx.Length);
        audioSource.PlayOneShot(sfx[idx]);
    }
}
