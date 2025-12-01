using UnityEngine;

public class EnableGameObject : MonoBehaviour
{
    [SerializeField] GameObject targetGO; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetGO.SetActive(true);
            Destroy(gameObject);
        }
    }
}
