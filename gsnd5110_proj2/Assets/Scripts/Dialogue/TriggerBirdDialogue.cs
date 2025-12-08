using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBirdDialogue : BubbleOnProximity
{
    [SerializeField] bool changeScene = false;
    [SerializeField] string nextScene;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBubble.SetActive(true);
            dialogueTMP.text = dialogue;
            PlaySfx();
            StartCoroutine(DisableBubble());
        }
    }
    protected override void OnTriggerExit(Collider other)
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
}
