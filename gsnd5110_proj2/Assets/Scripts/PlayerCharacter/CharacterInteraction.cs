using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    Interactable currInteractable = null;
    [SerializeField] Animator playerAnimator;
    PlayRandomAudio randomAudio;

    public void Start()
    {
        randomAudio = GetComponent<PlayRandomAudio>();
    }

    public void Interact()
    {
        if (currInteractable != null) 
        {
            playerAnimator.Play("Interact");
            randomAudio.PlayRandomSfx();
            currInteractable.RunInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            currInteractable = other.gameObject.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            currInteractable = null;
        }
    }
}
