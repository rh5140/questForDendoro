using UnityEngine;
using System.Collections;

public class UnlockGate : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    [SerializeField] private SpriteRenderer _sr;

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y + 5, startPosition.z);
    }

    public void Raise()
    {
        _sr.color = Color.yellow;
        transform.position = endPosition;
    }

    public void Lower()
    {
        _sr.color = Color.white;
        transform.position = startPosition;
    }
}
