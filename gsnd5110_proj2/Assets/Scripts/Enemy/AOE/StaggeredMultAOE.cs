using System.Collections;
using UnityEngine;

public class StaggeredMultAOE : EnemyAOE
{
    [SerializeField] GameObject[] aoe;
    [SerializeField] float delay = 1f;

    public override void UseAttack()
    {
        StartCoroutine(StaggerAtack());
    }

    IEnumerator StaggerAtack()
    {
        randomAudio.PlayRandomSfx();
        foreach (GameObject go in aoe)
        {
            yield return new WaitForSeconds(delay);
            go.GetComponent<EnemyAOE>().UseAttack();
        }
    }
}

