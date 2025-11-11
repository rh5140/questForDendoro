using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour
{
    [SerializeField] CharacterController player;
    [SerializeField] CharacterHealth playerHealth;
    [SerializeField] GameObject endScreen;
    Vector3 startingPosition;
    void Start()
    {
        startingPosition = player.transform.position;
    }

    public void RestartWithProgress()
    {
        player.enabled = false;
        Vector3 distanceToMove = startingPosition - player.transform.position;
        player.transform.position = startingPosition;
        player.enabled = true;
        // player.Move(distanceToMove);
        playerHealth.HealFull();
        endScreen.SetActive(false);
    }

}
