using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantSceneChanger : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level_6");
    }
}
