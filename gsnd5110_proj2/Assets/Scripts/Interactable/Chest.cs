using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] GameObject changeToThis;

    public override void RunInteraction()
    {
        Instantiate(changeToThis, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
