using TMPro;
using UnityEngine;

public class TriggerBossDialogue : MonoBehaviour
{
    [SerializeField] GameObject bossGO;
    BossController boss;
    [SerializeField] string bossDialogue;
    bool triggered = false;

    void Start()
    {
        boss = bossGO.GetComponent<BossController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.gameObject.tag == "Player")
        {
            boss.BossDialogue(bossDialogue);
            triggered = true;
        }
    }
}
