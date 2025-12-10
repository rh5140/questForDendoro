using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ShowGameObject(GameObject go)
    {
        go.SetActive(true);
    }

    public void HideGameObject(GameObject go)
    {
        go.SetActive(false);
    }
}
