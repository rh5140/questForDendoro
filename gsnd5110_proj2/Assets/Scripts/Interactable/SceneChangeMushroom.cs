using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeMushroom : Interactable
{
    [SerializeField] string nextSceneName;
    
    public override void RunInteraction()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
