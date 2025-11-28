using System.Collections;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] CharacterController player;
    [SerializeField] CharacterHealth playerHealth;
    [SerializeField] GameObject endScreen;
    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject animatedBody;
    [SerializeField] GameObject deadSprite;
    [SerializeField] FadeBlack fadeBlack;
    Vector3 startingPosition;
    
    void Start()
    {
        startingPosition = player.transform.position;
    }

    public void RestartWithProgress()
    {
        StartCoroutine(ResetPlayer());
    }

    IEnumerator ResetPlayer()
    {
        fadeBlack.RunFadeCoroutine(1f, 1f);
        yield return new WaitForSeconds(1.5f);
        player.enabled = false;
        player.transform.position = startingPosition;
        player.enabled = true;
        playerHealth.HealFull();
        endScreen.SetActive(false);
        deadSprite.SetActive(false);
        animatedBody.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerAnimator.Play("Idle");
        fadeBlack.RunFadeCoroutine(0f, 1f);
        yield return new WaitForSeconds(1f);
    }

}
