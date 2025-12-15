using UnityEngine;

public class MultRectAOE : EnemyAOE
{
    [SerializeField] GameObject[] rects;

    public override void UseAttack()
    {
        randomAudio.PlayRandomSfx();
        foreach (GameObject go in rects)
        {
            go.GetComponent<RectAOE>().UseAttack();
        }
    }
    
}
