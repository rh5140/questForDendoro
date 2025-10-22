using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sr;

    public void RunInteraction()
    {
        Debug.Log("RUNNING INTERACTION");
        if (_sr.color == Color.white) _sr.color = Color.yellow;
        else _sr.color = Color.white;
    }
}
