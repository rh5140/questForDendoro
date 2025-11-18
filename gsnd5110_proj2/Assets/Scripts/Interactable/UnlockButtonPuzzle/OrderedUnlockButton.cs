using UnityEngine;

public class OrderedUnlockButton : Interactable
{
    bool isPressed = false;
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] OrderedUnlockGate ug;
    [SerializeField] Sprite unpressed;
    [SerializeField] Sprite pressed;


    public override void RunInteraction()
    {
        if (isPressed) return;
        isPressed = true;
        _sr.sprite = pressed;
        ug.AddButton(this);
    }

    public void ResetButton()
    {
        isPressed = false;
        _sr.sprite = unpressed;
    }
}
