using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public PlayerData playerData;
    
    public SpriteRenderer helm;
    public SpriteRenderer l_arm;
    public SpriteRenderer waist;
    public SpriteRenderer body;
    public SpriteRenderer r_arm;
    public SpriteRenderer dead;

    void Awake()
    {
        helm.sprite = playerData.colorVariant.helm;
        l_arm.sprite = playerData.colorVariant.l_arm;
        waist.sprite = playerData.colorVariant.waist;
        body.sprite = playerData.colorVariant.body;
        r_arm.sprite = playerData.colorVariant.r_arm;
        dead.sprite = playerData.colorVariant.dead;
    }
}
