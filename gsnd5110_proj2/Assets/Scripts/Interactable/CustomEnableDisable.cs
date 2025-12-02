using UnityEngine;

public class CustomEnableDisable : UnlockButton
{
    [SerializeField] GameObject enable;
    [SerializeField] GameObject disable;
    public override void RunInteraction()
    {
        base.RunInteraction();
        enable.SetActive(true);
        disable.SetActive(false);
    }
}
