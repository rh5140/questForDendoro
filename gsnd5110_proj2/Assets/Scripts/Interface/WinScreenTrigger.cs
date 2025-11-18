using UnityEngine;

public class WinScreenTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _winscreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _winscreen.SetActive(true);
        }
    }
}
