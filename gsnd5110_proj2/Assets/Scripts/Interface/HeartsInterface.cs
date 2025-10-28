using UnityEngine;

public class HeartsInterface : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;

    public void RemoveHearts(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject child = transform.GetChild(0).gameObject;
            if (child != null) Destroy(child);
        }
    }

    public void AddHearts(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(_heartPrefab, transform);
        }
    }
}
