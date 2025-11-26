using UnityEngine;

public class HealingSpawnerButton : Interactable
{
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] Sprite unpressed;
    [SerializeField] Sprite pressed;

    public GameObject potion;
    public GameObject spawnPoint;
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
        Instantiate(potion, spawnPoint.transform.position, spawnPoint.transform.rotation);
        coolDown = true;
        curTime = 0f;
    }

}
