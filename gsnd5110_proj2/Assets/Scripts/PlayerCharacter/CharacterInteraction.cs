using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    Interactable currInteractable = null;
    AudioSource audioSource;
    [SerializeField] Animator playerAnimator;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (currInteractable != null) 
        {
            playerAnimator.Play("Interact");
            audioSource.Play();
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
