using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    Interactable currInteractable = null;

    public void Interact()
    {
        currInteractable.RunInteraction();
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
