using UnityEngine;

public class BossController : EnemyController
{
    protected override void Die()
    {
        _currHealth = 0;
        Destroy(transform.parent.gameObject);
    }
}
