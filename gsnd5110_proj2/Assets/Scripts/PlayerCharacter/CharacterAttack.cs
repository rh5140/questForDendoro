using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    // Might be messy...
    [SerializeField] Companion companion;

    public void Attack()
    {
        weapon.HitTarget();
        companion.Attack();
    }
}
