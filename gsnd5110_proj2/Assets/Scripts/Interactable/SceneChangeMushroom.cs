using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeMushroom : Interactable
{
    [SerializeField] string nextSceneName;
    CharacterController player;
    FadeBlack fadeBlack;

    void Start()
    {
        if (player == null) player = GameObject.Find("PlayerCharacter").GetComponent<CharacterController>();
        if (fadeBlack == null) fadeBlack = GameObject.Find("FadeBlack").GetComponent<FadeBlack>();
    }
    
    public override void RunInteraction()
    {
        StartCoroutine(WaitBeforeSceneChange());
    }

    IEnumerator WaitBeforeSceneChange()
    {
        player.enabled = false;
        fadeBlack.RunFadeCoroutine(1f, 0.5f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextSceneName);
    }
}
