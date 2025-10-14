using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _cc;

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
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = - move * movementSpeed * Time.deltaTime;
        _cc.Move(move);
    }

    public void Rotate(Vector2 rotationVector)
    {
        // _rotationY += rotationVector.x * rotationSpeed * Time.deltaTime;
        // transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }
}
