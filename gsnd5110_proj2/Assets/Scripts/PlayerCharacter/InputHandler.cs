using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    MOVE,
    IDLE,
    DIALOGUE,
}

public class InputHandler : MonoBehaviour
{
    private CharacterMovement _charMovement;
    private CharacterInteraction _charInteraction;
    private CharacterAttack _charAttack;
    
    private InputAction _moveAction;

    private PlayerState _state = PlayerState.MOVE; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        GameObject parent = transform.parent.gameObject;
        _charMovement = parent.GetComponent<CharacterMovement>();
        _charInteraction = parent.GetComponent<CharacterInteraction>();
        _charAttack = parent.GetComponent<CharacterAttack>();

        /*** CHANGE TO NOT USE GLOBAL SINGLETON***/ 
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case PlayerState.MOVE:
                TryMove();
                break;
            
            case PlayerState.IDLE:
                break;

            case PlayerState.DIALOGUE:
                break;
            
            default:
                break;
        }

    }

    public void OnMove()
    {
        _state = PlayerState.MOVE;
    }

    public void OnInteract()
    {
        TryInteract();
    }

    public void OnAttack()
    {
        TryAttack();
    }

    private void TryMove()
    {
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        _charMovement.Move(movementVector);
    }

    private void TryInteract()
    {
        _charInteraction.Interact();
    }

    private void TryAttack()
    {
        _charAttack.Attack();
    }
}
