using UnityEngine;

public class EnableOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject toEnable;
    
    void OnDestroy()
    {
        toEnable.SetActive(true);
    }
}
