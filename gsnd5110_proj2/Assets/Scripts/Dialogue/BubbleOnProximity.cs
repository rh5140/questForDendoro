using System.Collections;
using TMPro;
using UnityEngine;

public class BubbleOnProximity : MonoBehaviour
{
    [SerializeField] GameObject dialogueBubble;
    [SerializeField] TextMeshPro dialogueTMP;
    [SerializeField] public string dialogue;
    [SerializeField] string hitReaction;
    [SerializeField] bool changesWhenHit = true;
    private AudioSource audioSource;
    [SerializeField] AudioClip[] sfx;

    void Awake()
    {
        dialogueTMP.text = dialogue;
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(true);
            if (changesWhenHit) PlayRandomSfx();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Stop();
            dialogueBubble.SetActive(false);
        }
    }

    public void ReactToHit()
    {
        if (!changesWhenHit) return;
        dialogueTMP.text = hitReaction;
        StartCoroutine(RefreshDialogue());
    }

    IEnumerator RefreshDialogue()
    {
        yield return new WaitForSeconds(2f);
        dialogueTMP.text = dialogue;
    }

    public void RefreshDialogueImmediate()
    {
        dialogueTMP.text = dialogue;
    }

    private void PlayRandomSfx()
    {
        int idx = Random.Range(0, sfx.Length);
        audioSource.PlayOneShot(sfx[idx]);
    }
}
