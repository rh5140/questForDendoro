using UnityEngine;

public class HealingPickup : Interactable
{
    [SerializeField] CharacterHealth _charHealth; // idk if I want to structure it like this..
    [SerializeField] private int _healAmount;

    void Awake()
    {
        if (_charHealth == null) 
        {
            _charHealth = FindObjectOfType<CharacterHealth>(); // get rid of later
        }
    }

    public override void RunInteraction()
    {
        _charHealth.HealDamage(_healAmount);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
