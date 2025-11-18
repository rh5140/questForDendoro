using UnityEngine;

public class OrderedUnlockButton : Interactable
{
    bool pressed = false;
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] public Color startColor;
    [SerializeField] OrderedUnlockGate ug;

    public void Start()
    {
        _sr.color = startColor;
    }

    public override void RunInteraction()
    {
        if (pressed) return;
        pressed = true;
        _sr.color = Color.white;
        ug.AddButton(this);
    }

    public void ResetButton()
    {
        pressed = false;
        _sr.color = startColor;
    }
}
