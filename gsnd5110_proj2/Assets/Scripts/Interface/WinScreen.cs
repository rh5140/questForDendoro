using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private string _currScene;
    void Start()
    {
        _currScene = SceneManager.GetActiveScene().name;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(_currScene);
    }
}
