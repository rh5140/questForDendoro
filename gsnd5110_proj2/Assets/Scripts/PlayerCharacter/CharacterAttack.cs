using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    public void Attack()
    {
        weapon.HitTarget();
    }
}
