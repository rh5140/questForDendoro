using UnityEngine;
using System.Collections;

public class MimicEnemy : EnemyController
{
    EnemyRangedAttack rangeAttack;
    float currTime = 3;
    [SerializeField] float attackInterval = 5f;
    Vector3 startPosition;
    Vector3 jumpPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rangeAttack = GetComponent<EnemyRangedAttack>();
        startPosition = transform.position;
        jumpPosition = new Vector3(startPosition.x, startPosition.y + 5, startPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > attackInterval)
        {
            StartCoroutine(Jump());
            currTime = 0;
        }
    }

    private IEnumerator Jump()
    {
        float jumpDuration = 0.5f;
        float jumpTime = 0;

        while (jumpTime < jumpDuration)
        {
            jumpTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, jumpPosition, 2);
            yield return null;
        }
        StartCoroutine(Attack());
        yield return new WaitForSeconds(0.5f);   
        jumpTime = 0;
        while (jumpTime < jumpDuration)
        {
            jumpTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 2);
            yield return null;
        }

    }

    private IEnumerator Attack()
    {
        rangeAttack.UseRangedAttack();
        yield return null;
    }
}
