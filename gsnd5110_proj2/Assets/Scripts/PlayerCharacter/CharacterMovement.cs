using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _cc;
    [SerializeField] private SpriteRenderer _sr;

    public float movementSpeed = 10f;
    public float rotationSpeed = 5f;

    private float _rotationY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movementVector)
    {
        FlipSprite(movementVector.x);

        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * movementSpeed * Time.deltaTime;
        _cc.Move(move);
    }

    private void FlipSprite(float x)
    {
        if (x < 0) _sr.flipX = true;
        else if (x > 0) _sr.flipX = false;
    }
}
