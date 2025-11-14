using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _cc;
    [SerializeField] private GameObject _spriteArt;
    [SerializeField] private Weapon _weapon; // not sure if best approach
    [SerializeField] private Companion _companion; // not sure if best approach
    [SerializeField] private GameObject _companionSpriteArt;

    public float movementSpeed = 10f;
    public float rotationSpeed = 5f;

    private float _rotationY;
    private float _lastDirection;
    private Vector3 _weaponRightPosition;
    private Vector3 _weaponLeftPosition;
    
    private Vector3 _companionRightPosition;
    private Vector3 _companionLeftPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cc = GetComponent<CharacterController>();

        _weaponRightPosition = _weapon.gameObject.transform.localPosition;
        _weaponLeftPosition = new Vector3(-_weapon.gameObject.transform.localPosition.x, _weapon.gameObject.transform.localPosition.y, _weapon.gameObject.transform.localPosition.z);
        
        _companionRightPosition = _companion.gameObject.transform.localPosition;
        _companionLeftPosition = new Vector3(-_companion.gameObject.transform.localPosition.x, _companion.gameObject.transform.localPosition.y, _companion.gameObject.transform.localPosition.z);
    }

    public void Move(Vector2 movementVector)
    {
        if (movementVector.x != _lastDirection && movementVector.x != 0)
            FlipSprite(movementVector.x);

        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * movementSpeed * Time.deltaTime;
        _cc.Move(move);
    }

    private void FlipSprite(float x)
    {
        if (x > 0)
        {
            FlipX(true, _spriteArt);
            _weapon.gameObject.transform.localPosition = _weaponRightPosition;
            _companion.gameObject.transform.localPosition = _companionRightPosition;
            FlipX(true, _companionSpriteArt);
        }
        else if (x < 0)
        {
            FlipX(false, _spriteArt);
            _weapon.gameObject.transform.localPosition = _weaponLeftPosition;
            _companion.gameObject.transform.localPosition = _companionLeftPosition;
            FlipX(false, _companionSpriteArt);
        }
        _lastDirection = x;
    }

    private void FlipX(bool flip, GameObject targetSprite)
    {
        Vector3 flipX = targetSprite.transform.localScale;
        if (flip) flipX.x = -1;
        else flipX.x = 1;
        targetSprite.transform.localScale = flipX;
    }
}
