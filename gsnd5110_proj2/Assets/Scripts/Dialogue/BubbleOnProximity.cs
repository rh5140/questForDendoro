using System.Collections;
using TMPro;
using UnityEngine;

public class BubbleOnProximity : MonoBehaviour
{
    [SerializeField] protected GameObject dialogueBubble;
    [SerializeField] protected TextMeshPro dialogueTMP;
    [SerializeField] public string dialogue;
    [SerializeField] string hitReaction;
    [SerializeField] bool changesWhenHit = true;
    protected AudioSource audioSource;
    protected PlayRandomAudio randomAudio;

    protected void Awake()
    {
        dialogueTMP.text = dialogue;
        audioSource = GetComponent<AudioSource>();
        randomAudio = GetComponent<PlayRandomAudio>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(true);
            if (changesWhenHit) PlaySfx();
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (changesWhenHit) audioSource.Stop();
            dialogueBubble.SetActive(false);
        }
    }

    protected void PlaySfx()
    {
        randomAudio.PlayRandomSfx();
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
        randomAudio.PlayRandomSfx();
    }

    public void RefreshDialogueImmediate()
    {
        dialogueTMP.text = dialogue;
    }
}
