using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _cc;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Weapon _weapon; // not sure if best approach

    public float movementSpeed = 10f;
    public float rotationSpeed = 5f;

    private float _rotationY;
    private float _lastDirection;
    private Vector3 _weaponRightPosition;
    private Vector3 _weaponLeftPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _weaponRightPosition = _weapon.gameObject.transform.localPosition;
        _weaponLeftPosition = new Vector3(-_weapon.gameObject.transform.localPosition.x, _weapon.gameObject.transform.localPosition.y, _weapon.gameObject.transform.localPosition.z);
    }

    public void Move(Vector2 movementVector)
    {
        if (movementVector.x != _lastDirection)
            FlipSprite(movementVector.x);

        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * movementSpeed * Time.deltaTime;
        _cc.Move(move);
    }

    private void FlipSprite(float x)
    {
        if (x < 0)
        {
            _sr.flipX = true;
            _weapon.gameObject.transform.localPosition = _weaponLeftPosition;
        }
        else if (x > 0)
        {
            _sr.flipX = false;
            _weapon.gameObject.transform.localPosition = _weaponRightPosition;
        }
        _lastDirection = x;
    }
}
