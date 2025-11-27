using UnityEngine;

public class TeleportPad : Interactable
{
    public GameObject teleportPoint;
    [SerializeField] CharacterController player;

    void Start()
    {
        if (player == null) player = GameObject.Find("PlayerCharacter").GetComponent<CharacterController>();
    }

    public override void RunInteraction()
    {
        player.enabled = false;
        player.transform.position = teleportPoint.transform.position;
        player.enabled = true;
        indicator.SetActive(false);
    }
}
