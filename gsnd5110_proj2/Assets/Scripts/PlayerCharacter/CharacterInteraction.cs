using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    Interactable currInteractable = null;
    AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (currInteractable != null) 
        {
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
