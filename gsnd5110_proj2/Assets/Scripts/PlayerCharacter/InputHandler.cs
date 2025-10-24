using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private CharacterMovement _charMovement;
    private CharacterInteraction _charInteraction;
    private CharacterAttack _charAttack;
    
    private InputAction _moveAction;
    private InputAction _interactAction;
    private InputAction _attackAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        GameObject parent = transform.parent.gameObject;
        _charMovement = parent.GetComponent<CharacterMovement>();
        _charInteraction = parent.GetComponent<CharacterInteraction>();
        _charAttack = parent.GetComponent<CharacterAttack>();

        _moveAction = InputSystem.actions.FindAction("Move");
        _interactAction = InputSystem.actions.FindAction("Interact");
        _attackAction = InputSystem.actions.FindAction("Attack");

        _interactAction.performed += TryInteract;
        _attackAction.performed += TryAttack;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        _charMovement.Move(movementVector);
    }

    private void TryInteract(InputAction.CallbackContext context)
    {
        _charInteraction.Interact();
    }

    private void TryAttack(InputAction.CallbackContext context)
    {
        _charAttack.Attack();
    }

    private void OnDisable()
    {
        _interactAction.performed -= TryInteract;
        _attackAction.performed -= TryAttack;
    }
}
