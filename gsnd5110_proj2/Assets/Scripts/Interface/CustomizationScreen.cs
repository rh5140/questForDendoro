using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationScreen : MonoBehaviour
{
    public PlayerData playerData;
    public ColorVariantAssets orange;
    public ColorVariantAssets red;
    public ColorVariantAssets blue;
    public ColorVariantAssets green;
    public ColorVariantAssets white;

    public SpriteRenderer helm;
    public SpriteRenderer l_arm;
    public SpriteRenderer waist;
    public SpriteRenderer body;
    public SpriteRenderer r_arm;
    
    public void ChooseColor(string color)
    {
        if (color == "red")
            playerData.colorVariant = red;
        else if (color == "blue")
            playerData.colorVariant = blue;
        else if (color == "green")
            playerData.colorVariant = green;
        else if (color == "white")
            playerData.colorVariant = white;
        else
            playerData.colorVariant = orange;
        ChangeInSprite();
    }

    void ChangeInSprite()
    {
        helm.sprite = playerData.colorVariant.helm;
        l_arm.sprite = playerData.colorVariant.l_arm;
        waist.sprite = playerData.colorVariant.waist;
        body.sprite = playerData.colorVariant.body;
        r_arm.sprite = playerData.colorVariant.r_arm;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
