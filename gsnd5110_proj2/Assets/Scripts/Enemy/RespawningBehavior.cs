using UnityEngine;
using System.Collections;

public class RespawningBehavior : MonoBehaviour
{
    [SerializeField] private int _respawnTimer;
    [SerializeField] private GameObject _enemyToRespawn;
    [SerializeField] private GameObject _currEnemy;
    private bool _isRespawning = false;

    // Not ideal to check every update, would prefer to link it to EnemyController::Die somehow
    void Update()
    {
        if (_currEnemy == null && !_isRespawning) StartCoroutine(DelayBeforeRespawn(_respawnTimer));
    }

    private IEnumerator DelayBeforeRespawn(int waitTime)
    {
        _isRespawning = true;
        yield return new WaitForSeconds(waitTime);
        Instantiate(_enemyToRespawn, transform);
        _isRespawning = false;
    }
}
