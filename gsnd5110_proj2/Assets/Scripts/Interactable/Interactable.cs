using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    public virtual void RunInteraction()
    {
        Debug.Log("RUNNING INTERACTION");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            if (indicator != null) indicator.SetActive(true);
            else Debug.Log("Indicator for " + gameObject.name + " not found");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (indicator != null) indicator.SetActive(false);
        else Debug.Log("Indicator for " + gameObject.name + " not found");
    }
}
