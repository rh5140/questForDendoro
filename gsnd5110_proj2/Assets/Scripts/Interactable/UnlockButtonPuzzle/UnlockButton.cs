using UnityEngine;

public class UnlockButton : Interactable
{
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] Sprite unpressed;
    [SerializeField] Sprite pressed;
    [SerializeField] private UnlockGate _ug;

    public override void RunInteraction()
    {
        if (_sr.sprite == unpressed) 
        {
            _sr.sprite = pressed;
            _ug.Raise();
        }
    }
}
