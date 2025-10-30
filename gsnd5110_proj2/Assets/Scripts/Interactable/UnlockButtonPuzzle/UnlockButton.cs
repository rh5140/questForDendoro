using UnityEngine;

public class UnlockButton : Interactable
{
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private UnlockGate _ug;

    public override void RunInteraction()
    {
        if (_sr.color == Color.white) 
        {
            _sr.color = Color.yellow;
            _ug.Raise();
        }
        else
        {
            _sr.color = Color.white;
            _ug.Lower();
        } 
    }
}
