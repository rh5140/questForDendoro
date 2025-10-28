using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("MovementAndInteraction");
    }
}
