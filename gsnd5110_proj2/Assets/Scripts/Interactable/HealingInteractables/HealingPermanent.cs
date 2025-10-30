using UnityEngine;

public class HealingPermanent : Interactable
{
    [SerializeField] CharacterHealth _charHealth; // idk if I want to structure it like this..
    [SerializeField] private int _healAmount;

    public override void RunInteraction()
    {
        _charHealth.HealDamage(_healAmount);
    }
}
