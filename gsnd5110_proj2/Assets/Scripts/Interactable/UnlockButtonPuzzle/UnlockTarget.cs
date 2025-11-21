using UnityEngine;

public class UnlockTarget : MonoBehaviour
{
    private SpriteRenderer _sr;
    private bool _wasHit = false;
    [SerializeField] UnlockGate gate;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (_wasHit) return;
        if (collider.gameObject.tag == "FriendlyProjectile")
        {
            _sr.color = Color.orange;
            gate.Raise();
            _wasHit = true;
        }
    }
}
