using UnityEngine;

public class HealingSpawnerButton : Interactable
{
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] Sprite unpressed;
    [SerializeField] Sprite pressed;

    [SerializeField] GameObject potion;
    [SerializeField] GameObject[] spawnPoint;
    bool coolDown = false;
    
    float curTime = 0f;
    float interval = 5f;

    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > interval)
        {
            coolDown = false;
            _sr.sprite = unpressed;
        }
    }

    public override void RunInteraction()
    {
        if (coolDown) return;
        if (_sr.sprite == unpressed) 
        {
            _sr.sprite = pressed;
            SpawnPotion();
        }
    }

    void SpawnPotion()
    {
        int idx = Random.Range(0, spawnPoint.Length);
        Instantiate(potion, spawnPoint[idx].transform.position, spawnPoint[idx].transform.rotation);
        coolDown = true;
        curTime = 0f;
    }
}
